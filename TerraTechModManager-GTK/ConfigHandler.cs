using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TerraTechModManagerGTK
{
    public static class ConfigHandler
    {
        private static Dictionary<string, object> config = new Dictionary<string, object>();

        public static void ResetConfig()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"config.json");
            File.Delete(path);
        }

        public static void LoadConfig()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"config.json");
            if (File.Exists(path))
                try
                {
                    config = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(path));
                }
                catch (Exception E)
                {
                    Console.WriteLine("There was an error reading the config file!");
                    Console.WriteLine(E);
                    //NewMain.StartMessage += "There is a problem with the config.json file\n";
                }
        }
        public static void SaveConfig()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"config.json");
            File.WriteAllText(path, JsonConvert.SerializeObject(config));
        }

        /// <summary>
        /// Obtain value if exists, otherwise assign to provided default.
        /// </summary>
        /// <returns>Value in config if exists, else default.</returns>
        /// <param name="Key">Key to get value from, else write default to.</param>
        /// <param name="Default">Value to use if key is empty.</param>
        public static T CacheValue<T>(string Key, T Default)
        {
            if (config.ContainsKey(Key))
                return (T)config[Key];
            config[Key] = Default;
            return Default;
        }

        public static bool ContainsKey(string Key) => config.ContainsKey(Key);

        public static void SetValue(string Key, object Value)
        {
            config[Key] = Value;
        }
    }
}
