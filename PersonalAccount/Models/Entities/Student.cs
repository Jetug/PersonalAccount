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
        public string Country { get; set; }
        public int    Course { get; set; }
        public string Group { get; set; }
        public string Cathedra { get; set; }
        public string Department { get; set; }
        public Passport Passport { get; set; }
        public Visa Visa { get; set; }

        public Student()
        {
        }

        public Student(string name, string surname, string patronymic, string country, int course, string group, string cathedra, string department, Passport passport, Visa visa)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Country = country;
            Group = group;
            Course = course;
            Cathedra = cathedra;
            Department = department;
            Passport = passport;
            Visa = visa;
        }
    }
}
