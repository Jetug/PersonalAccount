using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Models.Entities
{
    /// <summary>
    /// Договор
    /// </summary>
    public class Contract
    {
        public Contract(int number, DateTime date)
        {
            Number = number;
            Date = date;
        }

        public int Number { get; set; }
        public DateTime Date {get; set;}
    }
}
