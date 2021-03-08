using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Models.Entities
{
    public class Visa
    {
        public Visa(int number, DateTime date)
        {
            Number = number;
            Date = date;
        }

        public int Number { get; set; }
        public DateTime Date { get; set; }
    }
}
