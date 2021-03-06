﻿using System;
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
            //FileStream LogFile = null;
            //try
            //{
            //    if (File.Exists("ttmm_log.txt"))
            //        File.Delete("ttmm_log.txt");
            //    LogFile = new FileStream("ttmm_log.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //    Console.SetOut(new StreamWriter(LogFile));
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Unable to write to ttmm_log.txt");
            //    Console.WriteLine(e.ToString());
            //}
            //try
            //{
            Application.Init();

            ConfigHandler.LoadConfig();

            string updateFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Update"); ;
            if (Directory.Exists(updateFolder))
            {
                try
                {
                    Directory.Delete(updateFolder);
                }
                catch { /* fail silently */}
            }

            if (ConfigHandler.CacheValue("skipstart", false))
                Start.text_st = Start.BootMain(Tools.TTRoot.Value);
            if (!Start.finished)
            {
                Start win = new Start();
                win.Show();
            }
            while (Tools.AllowedToRun)
            {
                Application.RunIteration();
                if (Tools.invoke.Count != 0)
                {
                    var list = Tools.invoke.ToArray();
                    Tools.invoke.Clear();
                    foreach (System.Action method in list)
                        method?.Invoke();
                }
            }
            //}
            //catch (Exception E)
            //{
            //    Console.WriteLine(E.ToString());
            //    while (E.InnerException != null)
            //    {
            //        E = E.InnerException;
            //        Console.WriteLine(E.ToString());
            //    }
            //}
            //finally
            //{
            //    if (LogFile != null)
            //        LogFile.Close();
            //}
        }
    }

    public static class Tools
    {
#warning CHANGE 'Version_Number' WITH EVERY RELEASE
        public const string Version_Number = "0.3.3";

        public const string GithubPage = "Aceba1/TerraTech-Mod-Manager-GTK";

        public static ConfigParam<string> GithubToken = new ConfigParam<string>("githubtoken", "");
        public static ConfigParam<string> TTRoot = new ConfigParam<string>("ttroot", GetUniqueRootPath());

        public static List<System.Action> invoke = new List<System.Action>();

        public static bool IsLinux
        {
            get
            {
                var p = Environment.OSVersion.Platform;
                return (p == PlatformID.Unix) || (p == PlatformID.MacOSX) || (p == (PlatformID)128);
            }
        }
        public static bool IsMacOSX { get; set; }

        public const string MonoMacOSX = "/Library/Frameworks/Mono.framework/Versions/Current/Commands/mono";

        public static bool AllowedToRun { get; set; } = true;

        private static string GetUniqueRootPath()
        {
            string path;
            if (IsLinux)
            {
                string home = Environment.GetEnvironmentVariable("HOME");
                path = home + "/.steam/steam/steamapps/common";
                if (!Directory.Exists(path))
                {
                    path = home + "/.local/share/Steam/steamapps/common";
                }
                if (!Directory.Exists(path)) // IsMacOSX - Should not hard guess at this stage, but if it is linux and neither path above is valid...
                {
                    path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Library/Application Support/Steam/steamapps/common");
                }

                path += "/TerraTech";
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
                path = @"C:\Program Files (x86)\Steam\steamapps\common\TerraTech";
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
