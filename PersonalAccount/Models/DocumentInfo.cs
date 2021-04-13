using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Models
{
    public static class DocumentInfo
    {
        //const string passportPath  = "wwwroot/Data/Documents/Passports";
        //const string passportPath  = "wwwroot/Data/Documents";
        //const string passportPath  = "wwwroot/Data/Documents";

        public static string GetPassportUploadingDate(int studentId)
        {
            string path = $"wwwroot/Data/Documents/Passports/Паспорт{studentId}.pdf";
            return LocalDB.ReadDate(path);
        }

        public static string GetVisaUploadingDate(int studentId)
        {
            string path = $"wwwroot/Data/Documents/Visas/Виза{studentId}.pdf";
            return LocalDB.ReadDate(path);
        }

        public static string GetContractUploadingDate(int studentId)
        {
            string path = $"wwwroot/Data/Documents/Contracts/Договор{studentId}.pdf";
            return LocalDB.ReadDate(path);
        }
    }
}
