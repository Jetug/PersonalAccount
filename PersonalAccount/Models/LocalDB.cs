using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonalAccount.Models
{
    public static class LocalDB
    {
        private const string dbFilePath = "wwwroot/Data/Documents/FileData.txt";
        private const string separator = "|";


        public static void WriteDate(string fileName, DateTime date)
        {
            string text = "";
            const string dateTimeFormat = "dd.MM.yyyy HH:mm:ss";

            using (StreamReader reader = new(dbFilePath))
            {
                text = reader.ReadToEnd();
            }

            text += "\n" + fileName + separator + date.ToString(dateTimeFormat);

            using (StreamWriter writer = new(dbFilePath, false))
            {
                writer.Write(text);
            }
        }

        public static string ReadDate(string fileName)
        {
            string text = "";

            using (StreamReader reader = new(dbFilePath))
            {
                text = reader.ReadToEnd();
            }
            string dataPattern = @".*";
            string pattern = fileName +  @"\" + separator + dataPattern;

            Regex regex = new(pattern);
            string res = regex.Match(text).Value;
            if(res != "")
                res = res.Split(separator)[1];
            return res;
        }
    }
}
