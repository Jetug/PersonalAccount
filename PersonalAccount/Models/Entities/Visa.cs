using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Models.Entities
{
    public class Visa
    {
        public Visa(int number, DateTime startDate, DateTime endDate)
        {
            Number = number;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int Number { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
