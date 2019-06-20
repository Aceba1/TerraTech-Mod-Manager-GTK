using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Gtk;

namespace TerraTechModManagerGTK
{
    enum TreeColumnInfo : byte
    {
        State,
        Name,
        Desc,
        Author,
        ModInfo
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();

            ConfigHandler.LoadConfig();
            
            if (ConfigHandler.CacheValue("skipstart", false))
                Start.text_st = Start.BootMain(Tools.TTRoot.Value);
            if (!Start.finished)
            {
                Start win = new Start();
                win.Show();
            }
            Application.Run();
        }
    }

    public static class Tools
    {
#warning CHANGE 'Version_Number' WITH EVERY RELEASE
        public const string Version_Number = "1.0.0";

        public static ConfigParam<string> GithubToken = new ConfigParam<string>("githubtoken", "");
        public static ConfigParam<string> TTRoot = new ConfigParam<string>("ttroot", GetUniqueRootPath());

        public static bool IsLinux
        {
            get
            {
                var p = Environment.OSVersion.Platform;
                return (p == PlatformID.Unix) || (p == PlatformID.MacOSX) || (p == (PlatformID)128);
            }
        }

        private static string GetUniqueRootPath()
        {
            string path;
            if (IsLinux)
            { 
                string home = Environment.GetEnvironmentVariable("HOME");
                path = home + "/.steam/steam/steamapps/common/TerraTech";
                if (!Directory.Exists(path))
                {
                    path = home + "/.local/share/Steam/steamapps/common/TerraTech";
                }
                if (!Directory.Exists(path))
                {
                    if (Directory.Exists(path + " Beta"))
                    {
                        path += " Beta";
                    }
                }
            }
            else
            {
                path = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\TerraTech";
                if (!Directory.Exists(path))
                {
                    if (Directory.Exists(path + " Beta"))
                    {
                        path += " Beta";
                    }
                }
            }
            return path;
        }
    }

    public class ConfigParam<T> where T : class
    {
        internal bool _dirty = true;
        internal T _value;
        internal string _key;

        public ConfigParam(string ID, T Default)
        {
            _key = ID;
            _value = Default;
        }

        public T Value
        {
            get
            {
                if (_dirty)
                {
                    _dirty = false;
                    _value = ConfigHandler.CacheValue(_key, _value);
                }
                return _value;
            }
            set
            {
                _dirty = false;
                ConfigHandler.SetValue(_key, value);
                _value = value;
            }
        }
    }
}
