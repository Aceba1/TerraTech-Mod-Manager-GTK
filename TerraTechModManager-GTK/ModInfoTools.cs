using System;
using System.IO;
using System.Collections.Generic;
using Gtk;
using Newtonsoft.Json;

namespace TerraTechModManagerGTK
{
    public static class ModInfoTools
    {
        public static string RootFolder;
        public static string DataFolder;
        public static string LastSearch;
        /// <summary>
        /// The local mods. Index with NAME property
        /// </summary>
        public static Dictionary<string, ModInfoHolder> LocalMods = new Dictionary<string, ModInfoHolder>();
        /// <summary>
        /// The github mods. Index with CLOUDNAME property
        /// </summary>
        public static Dictionary<string, ModInfoHolder> GithubMods = new Dictionary<string, ModInfoHolder>();

        public static ModInfoHolder lastGithubMod;
        private static int GithubMod(ModInfoHolder modinfo/*, bool IsMainThread*/)
        {
            int result = 0;
            bool foundOther = LocalMods.TryGetValue(modinfo.Name, out ModInfoHolder localModInfo);
            if (foundOther)
            {
                modinfo.FoundOther = 1;
                localModInfo.FoundOther = 1;
                if (!string.IsNullOrWhiteSpace(modinfo.CurrentVersion) && localModInfo.CurrentVersion != modinfo.CurrentVersion)
                {
                    //if (IsMainThread)
                    //{
                        MainWindow.ModListStoreLocal.SetValue(localModInfo.TreeIter, (int)TreeColumnInfo.Desc, "[Update Available] " + (string)MainWindow.ModListStoreLocal.GetValue(localModInfo.TreeIter, (int)TreeColumnInfo.Desc));
                        MainWindow.ModListStoreLocal.SetValue(localModInfo.TreeIter, (int)TreeColumnInfo.Name, "<b>" + (string)MainWindow.ModListStoreLocal.GetValue(localModInfo.TreeIter, (int)TreeColumnInfo.Name) + "</b>");
                    //}
                    //else Tools.invoke.Add(delegate
                    //{
                    //    MainWindow.ModListStoreLocal.SetValue(localModInfo.TreeIter, (int)TreeColumnInfo.Desc, "[Update Available] " + (string)MainWindow.ModListStoreLocal.GetValue(localModInfo.TreeIter, (int)TreeColumnInfo.Desc));
                    //    MainWindow.ModListStoreLocal.SetValue(localModInfo.TreeIter, (int)TreeColumnInfo.Name, "<b>" + (string)MainWindow.ModListStoreLocal.GetValue(localModInfo.TreeIter, (int)TreeColumnInfo.Name) + "</b>");
                    //});
                    result = 1;
                }
            }
            lastGithubMod = modinfo;
            //if (IsMainThread)
            //{
                modinfo.TreeIter = MainWindow.ModListStoreGithub.AppendValues(foundOther, modinfo.FancyName(), modinfo.InlineDescription, modinfo.Author, modinfo);
                GithubMods.Add(modinfo.CloudName, modinfo);
            //}
            //else Tools.invoke.Add(delegate
            //{
            //    modinfo.TreeIter = MainWindow.ModListStoreGithub.AppendValues(foundOther, modinfo.FancyName(), modinfo.InlineDescription, modinfo.Author, modinfo);
            //    GithubMods.Add(modinfo.CloudName, modinfo);
            //});
            return result;
        }

        public static bool GetGithubMod(Downloader.GetRepos.GithubRepoItem mod)
        {
            if (ModInfoHolder.TryGetModInfoFromRepo(mod, out var modinfo))
            {
                GithubMod(modinfo);
                //MainWindow.inst.Log("Added mod " + modinfo.CloudName);
                return true;
            }
            Console.WriteLine(mod.html_url + " is invalid!");
            return false;
        }

        public static bool GetFirstGithubMods(string Search = "")
        {
            int count = 0, updatecount = 0;
            LastSearch = Search;
            var mods = Downloader.GetRepos.GetFirstPage(LastSearch);
            foreach (var mod in mods)
            {
                if (ModInfoHolder.TryGetModInfoFromRepo(mod, out var modinfo))
                {
                    updatecount += GithubMod(modinfo);
                    //MainWindow.inst.Log("Added mod " + modinfo.CloudName);
                    count++;
                }
                else
                {
                    Console.WriteLine(mod.html_url + " is invalid!");
                }
            }
            MainWindow.inst.Log($"Found {count} Github mods" + (updatecount == 0 ? "" : " (" + updatecount.ToString() + " updates)"));
            return Downloader.GetRepos.MorePagesAvailable;
        }

        public static bool GetMoreGithubMods()
        {

            int count = 0, updatecount = 0;

            var mods = Downloader.GetRepos.GetNextPage();
            foreach (var mod in mods)
            {

                if (ModInfoHolder.TryGetModInfoFromRepo(mod, out var modinfo))
                {
                    updatecount += GithubMod(modinfo);
                    //MainWindow.inst.Log("Added mod " + modinfo.CloudName);
                    count++;
                }
                else
                {
                    Console.WriteLine(mod.html_url + " is invalid!");
                }
            }
            MainWindow.inst.Log($"Found {count} Github mods" + (updatecount == 0 ? "" : " (" + updatecount.ToString() + " updates)"));
            return Downloader.GetRepos.MorePagesAvailable;
        }

        public static void GetLocalMods(ListStore TreeList)
        {
            string qmods = Path.Combine(RootFolder, "QMods");
            if (!Directory.Exists(qmods))
            {
                Directory.CreateDirectory(qmods);
            }
            else foreach (string folder in Directory.GetDirectories(qmods))
                {
                    try
                    {
                        GetLocalMod_Internal(folder/*, false*/);
                    }
                    catch (Exception E)
                    {
                        Console.WriteLine("There was a problem handling a local mod: \n" + E.Message + "\nAt " + folder);
                    }
                }

            //qmods = Path.Combine(RootFolder, "QMods-Disabled");
            //if (Directory.Exists(qmods))
            //{
            //    foreach (string folder in Directory.EnumerateDirectories(qmods))
            //    {
            //        try
            //        {
            //            GetLocalMod_Internal(folder, true);
            //        }
            //        catch (Exception E)
            //        {
            //            Console.WriteLine("There was a problem handling a local mod: \n" + E.Message + "\nAt " + folder);
            //        }
            //    }
            //}
        }

        public static void GetLocalMod_Internal(string path /*, bool IsDisabled = false*/ /*, bool IsMainThread*/)
        {
            string modjson = path + "/mod.json";
            string ttmmjson = path + "/ttmm.json";
            if (File.Exists(modjson))
            {
                var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(modjson));
                ModInfoHolder modInfo = null;
                if (File.Exists(ttmmjson))
                {
                    try
                    {
                        modInfo = JsonConvert.DeserializeObject<ModInfoHolder>(File.ReadAllText(ttmmjson), new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore });
                    }
                    catch { Console.WriteLine("Reading ModInfo file from " + path + " failed!"); }
                }
                if (modInfo != null)
                {
                    modInfo.State = /*IsDisabled ? ModInfoHolder.ModState.Disabled :*/ (Convert.ToBoolean(json["Enable"]) ? ModInfoHolder.ModState.Enabled : ModInfoHolder.ModState.Inactive);
                    modInfo.FilePath = path;
                    modInfo.CloudName = modInfo.CloudName[0] == '/' ? modInfo.CloudName.Substring(1) : modInfo.CloudName;
                }
                else
                {
                    modInfo = new ModInfoHolder
                    {
                        Name = json["DisplayName"] as string,
                        Author = json["Author"] as string,
                        State = /*IsDisabled ? ModInfoHolder.ModState.Disabled :*/ (Convert.ToBoolean(json["Enable"]) ? ModInfoHolder.ModState.Enabled : ModInfoHolder.ModState.Inactive),
                        FilePath = path,
                        InlineDescription = json["Id"] as string
                    };
                }

                if (LocalMods.TryGetValue(modInfo.Name, out ModInfoHolder oldModInfo))
                {
                    //if (IsMainThread)               MainWindow.ModListStoreLocal.Remove(ref oldModInfo.TreeIter);
                    //else
                    Tools.invoke.Add(delegate{ MainWindow.ModListStoreLocal.Remove(ref oldModInfo.TreeIter); });
                }
                //if (IsMainThread)
                //{
                //    modInfo.TreeIter = MainWindow.ModListStoreLocal.InsertWithValues(0, modInfo.State == ModInfoHolder.ModState.Enabled, modInfo.FancyName(), modInfo.InlineDescription, modInfo.Author, modInfo);
                //    LocalMods[modInfo.Name] = modInfo;
                //}
                //else 
                Tools.invoke.Add(delegate
                {
                    modInfo.TreeIter = MainWindow.ModListStoreLocal.InsertWithValues(0, modInfo.State == ModInfoHolder.ModState.Enabled, modInfo.FancyName(), modInfo.InlineDescription, modInfo.Author, modInfo);
                    LocalMods[modInfo.Name] = modInfo;
                });
                //if (modInfo.CloudName != null && modInfo.CloudName != "" && flag)
                //{
                //    string version = FindServerMod(modInfo.CloudName, ImmediatelyFromCloud);
                //    if (version != "" && version != modInfo.CurrentVersion)
                //    {
                //        Log("Update available for " + modInfo.CloudName + " (" + version + ")", Color.Turquoise);
                //        modInfo.Visible.SubItems[2].Text = "[Update Available] " + modInfo.Visible.SubItems[2].Text;
                //        modInfo.Visible.UseItemStyleForSubItems = false;
                //        modInfo.Visible.SubItems[1].Font = new Font(modInfo.Visible.SubItems[1].Font, FontStyle.Bold);
                //    }
                //}
            }
        }
    }
}