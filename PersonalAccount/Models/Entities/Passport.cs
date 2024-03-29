﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Models.Entities
{
    public class Passport
    {
        public Passport(string number)
        {
            Number = number;
        }

        public string Number { get; set; }
        public DateTime Date { get; set; } = new(2000, 11, 12);
    }
}
