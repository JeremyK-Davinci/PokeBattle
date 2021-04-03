using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PokeBattle.Utilities
{
    public class JSON
    {
        private static JsonSerializerSettings JSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            ObjectCreationHandling = ObjectCreationHandling.Replace
        };

        public static void Write<T>(T Object, string filePath)
        {
            if (!File.Exists(filePath))
                File.Create(filePath);

            string json = JsonConvert.SerializeObject(Object, Formatting.Indented, JSettings);
            File.WriteAllText(filePath, json);
        }

        public static T Read<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);

            try
            {
                T Result = JsonConvert.DeserializeObject<T>(json, JSettings);
                return Result;
            }
            catch (JsonReaderException)
            {
                if (json.Contains("“") || json.Contains("”"))
                {
                    try
                    {
                        T Result = JsonConvert.DeserializeObject<T>(json.Replace('“', '"').Replace('”', '"'), JSettings);
                        return Result;
                    }
                    catch { }
                }
                throw;
            }
        }
    }
}
