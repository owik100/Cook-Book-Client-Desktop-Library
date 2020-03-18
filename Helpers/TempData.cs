using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cook_Book_Client_Desktop_Library.Helpers
{
    public static class TempData
    {
        public static string GetTempFolderPathOrCreate()
        {
            try
            {
                Directory.CreateDirectory(Path.GetTempPath() + @"Cook Book\");
                return Path.GetTempPath() + @"Cook Book\";
            }
            catch (Exception)
            {
                throw;
            }         
        }

        public static string GetImagePath(string name)
        {
            string path = "";
            try
            {
                path = Path.GetTempPath() + @"Cook Book\" + $@"{name}";
                return path;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool ImageExistOnDisk(string name)
        {
            bool output = false;

            try
            {
                string path = Path.GetTempPath() + @"Cook Book\" + $@"{name}";

                if (File.Exists(path))
                {
                    output = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
           
            return output;
        }
    }
}
