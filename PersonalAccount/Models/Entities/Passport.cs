using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Models.Entities
{
    public class Passport
    {
        public Passport(int number)
        {
            Number = number;
        }

        public int Number { get; set; }
    }
}
