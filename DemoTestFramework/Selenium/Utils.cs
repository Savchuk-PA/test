using System;
using System.IO;

namespace Selenium
{
    public class Utils
    {

        public static string GetRandomEmail()
        {
            DateTime dateTime = DateTime.Now;
            return dateTime.Ticks.ToString() + "@gmail.com";
        }
        
        
        public static string GetFilePathByFileName(string fileName)
        {
            //Directory.GetCurrentDirectory()
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(directory, "../../../" + fileName);
            string sFilePath = Path.GetFullPath(sFile);
            return sFilePath;
        }
        
    }
}