using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonalAccount.Models
{
    public static class Searcher
    {
        public static bool IsMatch(string line, string word)
        {
            Regex regex = new(word);
            return regex.IsMatch(line);
        }
    }
}
