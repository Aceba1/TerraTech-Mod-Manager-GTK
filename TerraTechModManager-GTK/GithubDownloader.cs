using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace TerraTechModManagerGTK
{
    namespace Downloader
    {
        public static class GetUpdateInfo
        {
            public static GithubReleaseItem GetRelease(string CloudName)
            {
                return WebClientHandler.DeserializeApiCall<GithubReleaseItem>("https://api.github.com/repos/" + CloudName + "/releases/latest");
            }

            public class GithubReleaseItem
            {
                public string tag_name;
                public string name;
                public string body;
                public string html_url;
            }
        }

        public static class GetRepos
        {
            public static long Page { get; internal set; }
            public static long TotalCount { get; internal set; }
            public static long Counted { get; internal set; }
            public static string Search { get; internal set; }
            public static bool MorePagesAvailable
            {
                get => Counted < TotalCount;
            }

            public static GithubRepoItem GetOneRepo(string CloudName)
            {
                return WebClientHandler.DeserializeApiCall<GithubRepoItem>("https://api.github.com/repos/" + CloudName);
            }

            public static GithubRepoItem[] GetFirstPage(string Search = "")
            {
                GetRepos.Search = Uri.EscapeUriString(Search);
                var repos = WebClientHandler.DeserializeApiCall<GithubRepos>("https://api.github.com/search/repositories?q=topic:ttqmm" + (GetRepos.Search != "" ? "+" + Search : ""));
                Counted = repos.items.Length;
                Page = 0;
                TotalCount = repos.total_count;
                return repos.items;
            }

            public static GithubRepoItem[] GetNextPage()
            {
                Page++;
                var repos = WebClientHandler.DeserializeApiCall<GithubRepos>("https://api.github.com/search/repositories?q=topic:ttqmm" + (Search != "" ? "+" + Search : "") + "&page:" + Page.ToString());
                Counted += repos.items.Length;
                if (TotalCount != repos.total_count)
                {
                    MainWindow.inst.Log("Something has changed while this session was opened!");
                    TotalCount = repos.total_count;
                }
                return repos.items;
            }

            public class GithubRepos
            {
                public long total_count;
                public GithubRepoItem[] items;
            }

            public class GithubRepoItem
            {
                public string full_name;
                public string name;
                public string description;
                public string html_url;
                public string pushed_at;
            }
        }


        //https://api.github.com/search/repositories?q=topic:ttqmm
        //https://api.github.com/search/repositories?q=topic:ttqmm&page:0



        public static class DownloadFolder
        {
            public static byte KillDownload;

            public static IEnumerable<string> Download(string RepositoryPath, string CloudName, string DownloadPath)
            {
                string StartBranch = RepositoryPath.Substring(RepositoryPath.IndexOf("tree/master/") + 11);
                MainWindow.inst.Log(GetApiUrl(CloudName, StartBranch));
                var Entries = WebClientHandler.DeserializeApiCall<GithubItem[]>(GetApiUrl(CloudName, StartBranch));
                foreach (var entry in Entries)
                {
                    if (entry.type == "file" && entry.name == "mod.json")
                    {
                        DownloadPath = Path.Combine(DownloadPath, CloudName.Substring(CloudName.LastIndexOf('/') + 1));
                        break;
                    }
                }
                return RecursiveDownload(Entries, DownloadPath);
            }

            public static string GetApiUrl(string CloudName, string BranchingPath) => "https://api.github.com/repos/" + CloudName + "/contents" + BranchingPath;

            private static List<string> RecursiveDownload(IEnumerable<GithubItem> entries, string DownloadFolder, string CurrentPath = "")
            {
                List<string> result = new List<string>();
                try
                {
                    foreach (var item in entries)
                    {
                        if (KillDownload != 0)
                        {
                            MainWindow.inst.Log("The download was killed, but it did not finish!");
                            return result;
                        }
                        var localItem = item;

                        if (localItem.type == "dir")
                        {
                            if (!Directory.Exists(DownloadFolder + CurrentPath + "/" + localItem.name))
                            {
                                Directory.CreateDirectory(DownloadFolder + CurrentPath + "/" + localItem.name);
                            }

                            var subEntries = WebClientHandler.DeserializeApiCall<GithubItem[]>(localItem.url);
                            if (!subEntries.Any())
                            {
                                continue;
                            }

                            result.AddRange(RecursiveDownload(subEntries, DownloadFolder, CurrentPath + "/" + localItem.name));
                        }
                        else if (localItem.type == "file")
                        {
                            if (localItem.name == "mod.json")
                            {
                                result.Add(DownloadFolder + CurrentPath);
                            }
                            using (var wc = new WebClient())
                            {
                                MainWindow.inst.Log("Downloading " + CurrentPath + "/" + localItem.name);
                                string filepath = DownloadFolder + CurrentPath + "/" + localItem.name;
                                if (File.Exists(filepath))
                                {
                                    while (true)
                                    {
                                        try
                                        {
                                            File.Delete(filepath);
                                            break;
                                        }
                                        catch (Exception E)
                                        {
                                            MainWindow.inst.Log("File is occupied!\n" + E.Message);
                                            System.Threading.Thread.Sleep(10000);
                                        }
                                    }
                                }
                                while (true)
                                {
                                    try
                                    {
                                        wc.DownloadFile(localItem.download_url, filepath);
                                        break;
                                    }
                                    catch (Exception E)
                                    {
                                        MainWindow.inst.Log("Could not download " + localItem.name + "!\n" + E.Message);

                                        System.Threading.Thread.Sleep(30000);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainWindow.inst.Log(ex.Message);
                }
                return result;
            }

            public class GithubItem
            {
                public string name = null;
                public string url = null;
                public string download_url = null;
                public string path = null;
                public long size = 0;
                public string type = null;
            }
        }

        internal static class WebClientHandler
        {
            public static T DeserializeApiCall<T>(string ApiUrl)
            {
                string Token = Tools.GithubToken.Value;
                WebClient webClient = new WebClient();
            Retry:
                webClient.Headers.Add("user-agent", "ttmm-downloader-client");
                bool flag = false;
                if (Token != null && Token != "" && Token != "Github Token")
                {
                    webClient.Headers.Add("Authorization", "Token " + Token);
                    flag = true;
                }
                try
                {
                    string jsonData = webClient.DownloadString(ApiUrl);
                    return JsonConvert.DeserializeObject<T>(jsonData);
                }
                catch (Exception E)
                {
                    if (flag)
                    {
                        Token = "";
                        MainWindow.inst.Log("Skipping Github Token");
                        webClient = new WebClient();
                        goto Retry;
                    }
                    throw new Exception($"Could not access API!\n{(E.Message.Contains("Forbidden") ? "(Github Rate Limiting: Try setting a Github user token in the Config)\n" : "")}{E.Message}\n{ApiUrl}");
                }
            }
        }

        static class ModDownloader
        {
            public static List<ModInfoHolder> Downloads = new List<ModInfoHolder>();
            static Task CurrentDownload;
            static Gtk.ListStore ModStore;

            public static bool AddModDownload(ModInfoHolder ModBeingDownloaded, Gtk.ListStore ModStore)
            {
                ModDownloader.ModStore = ModStore;
                List<ModInfoHolder> neededmods = new List<ModInfoHolder>();
                foreach (var modname in ModBeingDownloaded.RequiredModNames)
                {
                    if (!ModInfoTools.GithubMods.TryGetValue(modname, out ModInfoHolder modInfo))
                    {
                        if (!ModInfoHolder.TryGetModInfoFromRepo(GetRepos.GetOneRepo(modname), out modInfo))
                        {
                            MainWindow.inst.Log("Could not find dependency! (" + modname + ")");
                            continue;
                        }
                    }
                    neededmods.Add(modInfo);
                }
                Downloads.Add(ModBeingDownloaded);
                foreach (ModInfoHolder mod in neededmods)
                {
                    Downloads.Add(mod);
                }
                CycleDownloads();
                return true;
            }

            private static void CycleDownloads()
            {
                if (Downloads.Count != 0 && CurrentDownload == null)
                {
                    var downloadinfo = Downloads[0];
                    SetCurrentDownload(downloadinfo.FilePath, downloadinfo.CloudName);
                }
            }

            private static void SetCurrentDownload(params string[] Parameters)
            {
                CurrentDownload = new Task(Download_Internal, Parameters);
                CurrentDownload.Start();
                return;
            }

            private static void Download_Internal(object Params)
            {
                var param = Params as string[];
                MainWindow.inst.Log("Downloading " + param[1]);
                string Folder = null;
                try
                {
                    Folder = Downloader.DownloadFolder.Download(param[0], param[1], Path.Combine(Tools.TTRoot.Value, "QMods")).First();
                    if (DownloadFolder.KillDownload != 0)
                    {
                        MainWindow.inst.Log("Download was killed!");
                        if (DownloadFolder.KillDownload == 2)
                        Directory.Delete(Folder, true);
                        DownloadFolder.KillDownload = 0;
                        Download_Internal_2();
                        return;
                    }
                    if (!ModInfoTools.GithubMods.TryGetValue(param[1], out ModInfoHolder serverMod))
                    {
                        throw new Exception("Could not find the downloaded mod!");
                    }
                    if (serverMod.Description == null)
                        serverMod.GetDescription();
                    if (ModInfoTools.LocalMods.TryGetValue(serverMod.Name, out ModInfoHolder existingMod) && new DirectoryInfo(existingMod.FilePath).FullName != new DirectoryInfo(Folder).FullName)
                    {
                        MainWindow.inst.Log("Overlapping existing mod folder with downloaded folder...");
                        try
                        {
                            foreach (var file in new DirectoryInfo(existingMod.FilePath).GetFiles("*", SearchOption.AllDirectories))
                            {
                                string newPath = Path.Combine(Folder, file.FullName.Substring(existingMod.FilePath.Length + 1));
                                Console.WriteLine(newPath);
                                if (!File.Exists(newPath))
                                {
                                    File.Move(file.FullName, newPath);
                                }
                                else
                                {
                                    File.Delete(file.FullName);
                                }
                            }
                            Directory.Delete(existingMod.FilePath);
                        }
                        catch (Exception E)
                        {
                            MainWindow.inst.Log("Could not overlap existing mod folder with downloaded folder!\n" + E.Message);
                        }
                    }
                    File.WriteAllText(Path.Combine(Folder, "ttmm.json"), JsonConvert.SerializeObject(serverMod, Formatting.Indented));
                    ModInfoTools.GetLocalMod_Internal(Folder/*, false*//*, false*/);
                    Tools.invoke.Add(delegate
                    {
                        MainWindow.ModListStoreGithub.SetValue(serverMod.TreeIter, (int)TreeColumnInfo.State, true);
                    });
                    MainWindow.inst.Log("Done!");
                }
                catch (Exception e)
                {
                    MainWindow.inst.Log(e.Message);
                    if (!string.IsNullOrEmpty(Folder))
                    {
                        Directory.Delete(Folder, true);
                    }
                    MainWindow.inst.Log("Failed!\n" + e.Message);
                    Console.WriteLine(e.StackTrace);
                }
                Download_Internal_2();
            }

            static void Download_Internal_2()
            {
                CurrentDownload = null;
                Downloads.RemoveAt(0);
                CycleDownloads();
            }
        }
    }
}