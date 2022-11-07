using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using DemoTestFramework.models;
using Newtonsoft.Json;

namespace DemoTestFramework.helpers
{
    public class FileHelper
    {
        public static string GetFilePathByFileName(string fileName)
        {
            //Directory.GetCurrentDirectory()
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(directory, "../../../validationTests/contracts/" + fileName);
            string sFilePath = Path.GetFullPath(sFile);
            return sFilePath;
        }


        public static void ReadJsonFromFile(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Planet>? planets = JsonConvert.DeserializeObject<List<Planet>>(json);
            }
        }
        
        
    }
}