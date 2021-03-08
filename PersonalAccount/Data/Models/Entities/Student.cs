using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Data.Models.Entities
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

        public Student(string name, string surname, string patronymic, string country, int course, string cathedra, string department)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Country = country;
            Course = course;
            Cathedra = cathedra;
            Department = department;
        }

        public Student()
        {
        }
    }
}
