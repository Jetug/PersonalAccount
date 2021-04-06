using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Models
{
    public class FileDownloader
    {
        public static void DownloadPassport()
        {
            string path = "wwwroot/Data/Documents/Passports/Паспорт.pdf";
            File.ReadAllBytes(path);
        }

        public static void DownloadVisa()
        {
            string path = "wwwroot/Data/Documents/Visas/Виза.pdf";
            File.ReadAllBytes(path);
        }

        public static void DownloadContract()
        {
            string path = "wwwroot/Data/Documents/Contracts/Договор.pdf";
            File.ReadAllBytes(path);
        }

        
    }
}
