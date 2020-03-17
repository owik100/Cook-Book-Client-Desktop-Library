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
            System.IO.Directory.CreateDirectory(Path.GetTempPath() + @"Cook Book\");
            return Path.GetTempPath() + @"Cook Book\";
        }
    }
}
