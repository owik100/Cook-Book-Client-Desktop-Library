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
                if (File.Exists(GetImagePath(name)))
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

        public static void DeleteUnusedImages(List<string> dontDeletetheseImages)
        {
            List<string> ImagesInFolder = new List<string>();

            try
            {
                string[] fileArray = Directory.GetFiles(Path.GetTempPath() + @"Cook Book\");

                foreach (var item in fileArray)
                {
                    ImagesInFolder.Add(Path.GetFileName(item));
                }

                foreach (var item in dontDeletetheseImages)
                {
                    ImagesInFolder.RemoveAll(x => x == item);
                }

                foreach (var item in ImagesInFolder)
                {
                    File.Delete(GetImagePath(item));
                }

            }
            catch (IOException)
            {

                //
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}
