using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Models
{
    public class FileDownloader
    {
        public static byte[] DownloadPassport(int studentId)
        {
            string path = $"wwwroot/Data/Documents/Passports/Паспорт{studentId}.pdf";
            return File.ReadAllBytes(path);
        }

        public static byte[] DownloadVisa(int studentId)
        {
            string path = $"wwwroot/Data/Documents/Visas/Виза{studentId}.pdf";
            return File.ReadAllBytes(path);
        }

        public static byte[] DownloadContract(int studentId)
        {
            string path = $"wwwroot/Data/Documents/Contracts/Договор{studentId}.pdf";
            return File.ReadAllBytes(path);
        }

        
    }
}
