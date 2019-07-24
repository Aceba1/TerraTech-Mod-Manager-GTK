using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TerraTechModManagerGTK
{
    public class ModInfoHolder
    {
        public string Name; //Json
        public string Author; //Json
        public string CloudName; //Json
        public string InlineDescription; //Json
        public string Description; //Json
        public string Site; //Json
        public string[] RequiredModNames; //Json
        public string CurrentVersion; //Json

        [JsonIgnore]
        public int FoundOther;

        [JsonIgnore]
        public ModState State;

        [JsonIgnore]
        public string FilePath;

        [JsonIgnore]
        public Gtk.TreeIter TreeIter;

        public ModInfoHolder() { }

        //public ModInfoHolder(JObject Value)
        //{
        //    Name = Value["Name"].ToObject;
        //    Author = Value["Author"].ToString();
        //    CloudName = Value["CloudName"].ToString();
        //    InlineDescription = Value["InlineDescription"].ToString();
        //    Description = Value["Description"].ToString();
        //    Site = Value["Site"].ToString();
        //    var dependencies = Value["RequiredModNames"];
        //    RequiredModNames = new string[dependencies.Count];
        //    for (int i = 0; i < dependencies.Count; i++)
        //    {
        //        RequiredModNames[i] = dependencies[i];
        //    }
        //    CurrentVersion = Value["CurrentVersion"];
        //}

        public static bool TryGetModInfoFromRepo(Downloader.GetRepos.GithubRepoItem repo, out ModInfoHolder result)
        {
            result = new ModInfoHolder()
            {
                State = ModState.Server,
                Name = repo.name,
                CloudName = repo.full_name,
                Author = repo.full_name.Substring(0, repo.full_name.IndexOf(repo.name) - 1),
                InlineDescription = repo.description,
                Site = "https://github.com/" + repo.full_name,
                CurrentVersion = repo.pushed_at
            };

            var client = new WebClient();
            string linkspath = "https://raw.githubusercontent.com/" + repo.full_name + "/master/LINKS.";

            string links = "";
            try
            {
                links = client.DownloadString(linkspath + "md");
            }
            catch
            {
                try
                {
                    links = client.DownloadString(linkspath + "txt");
                }
                catch
                {
                    Console.WriteLine("Mod is not set up properly: Neither LINKS.txt file present");
                    result = null;
                    return false;
                }
            }
            result.FilePath = "";
            var linkarray = links.Split('\n', '\r');
            result.FilePath = linkarray[0];
            result.RequiredModNames = new string[linkarray.Length - 1];
            int EmptySpace = -1;
            for (int i = 1; i < linkarray.Length; i++)
            {
                string item = linkarray[i];
                if (item == "")
                {
                    EmptySpace--;
                    continue;
                }
                result.RequiredModNames[i + EmptySpace] = item[0] == '/' ? item.Substring(1) : item;
            }
            Array.Resize(ref result.RequiredModNames, linkarray.Length + EmptySpace);
            return true;
        }

        public string GetDescription()
        {
            if (string.IsNullOrEmpty(Description))
            {
                var client = new WebClient();
                string descpath = "https://raw.githubusercontent.com/" + CloudName + "/master/DESC.";
                bool FileExists = true;
                string desc = "";
                try
                {
                    desc = client.DownloadString(descpath + "txt");
                }
                catch
                {
                    try
                    {
                        desc = client.DownloadString(descpath + "md");
                    }
                    catch
                    {
                        try
                        {
                            desc = client.DownloadString("https://raw.githubusercontent.com/" + CloudName + "/master/README.md");
                        }
                        catch
                        {
                            FileExists = false; // File doesn't exist
                        }
                    }
                }
                if (FileExists)
                {
                    Description = desc; // DESCRIPTION
                }
                else
                {
                    Description = "No description could be found";
                }
            }
            return Description;
        }

        [JsonIgnore]
        private string _fancyName;
        public string FancyName()
        {
            if (_fancyName == null)
            {
                string result = Name.Substring(Name.StartsWith("TTQMM-") ? 6 : 0).Replace("-", "").Replace("_", "");
                for (int i = 1; i < result.Length; i++)
                {
                    if (char.IsUpper(result[i]) && char.IsLower(result[i - 1]))
                    {
                        result = result.Insert(i, " ");
                        i++;
                    }
                }
                _fancyName = result;
            }
            return _fancyName;
        }

        public enum ModState : byte
        {
            Enabled = 0,
            Inactive = 1,
            //Disabled = 2,
            Server = 3
        }

        public void EditModJson(string Parameter, object Value)
        {
            string path = System.IO.Path.Combine(FilePath, "mod.json");
            var modJson = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string, object>>(File.ReadAllText(path));
            modJson[Parameter] = Value;
            File.WriteAllText(path, JsonConvert.SerializeObject(modJson, Formatting.Indented));
        }

        //public JsonValue ToJson()
        //{
        //    JsonValue result = new JsonObject
        //    {
        //        ["Name"] = Name,
        //        ["Author"] = Author,
        //        ["CloudName"] = CloudName,
        //        ["InlineDescription"] = InlineDescription,
        //        ["Description"] = Description,
        //        ["Site"] = Site,
        //        ["CurrentVersion"] = CurrentVersion
        //    };
        //    var dependencies = new JsonArray();
        //    for (int i = 0; i < RequiredModNames.Length; i++)
        //    {
        //        dependencies.Add(RequiredModNames[i]);
        //    }
        //    result["RequiredModNames"] = dependencies;
        //    return result;
        //}
    }
}