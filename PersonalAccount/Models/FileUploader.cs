using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Models
{
    public static class FileUploader
    {
        const string dataPath = "wwwroot/Data/Documents";

        public static void UploadPassport(IFormFile file, int studentId)
        {
            string path = $"wwwroot/Data/Documents/Passports/Паспорт{studentId}.pdf";

            Upload(file, studentId, path);
        }

        public static void UploadVisa(IFormFile file, int studentId)
        {
            string path = $"wwwroot/Data/Documents/Visas/Виза{studentId}.pdf";

            Upload(file, studentId, path);
        }

        public static void UploadContract(IFormFile file, int studentId)
        {
            string path = $"wwwroot/Data/Documents/Contracts/Договор{studentId}.pdf";

            Upload(file, studentId, path);
        }

        private static void Upload(IFormFile file, int studentId, string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
            LocalDB.WriteDate(path, DateTime.Now);
        }
    }
}
