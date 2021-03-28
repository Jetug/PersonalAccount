using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Models.Entities
{
    public class Student
    {
        public string Name  { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDay { get; set; }
        public string Sex { get; set; }
        public string Country { get; set; }
        public string Institute { get; set; }

        //public string Group { get; set; }
        //public int    Course { get; set; }
        //public string Cathedra { get; set; }
        //public string Department { get; set; }

        public Contract Contract { get; set; }
        public Passport Passport { get; set; }
        public Visa Visa { get; set; }

        public Student()
        {
        }

        public Student(string name, string surname, string patronymic, DateTime birthDay, string sex, string country, string institute,
             Passport passport, Visa visa, Contract contract)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDay = birthDay;
            Sex = sex;
            Country = country;
            Institute = institute;
            Contract = contract;
            Passport = passport;
            Visa = visa;
        }
    }
}
