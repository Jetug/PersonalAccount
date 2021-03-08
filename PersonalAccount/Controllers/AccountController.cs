using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Controllers
{
    public class AccountController : Controller
    {
        List<Student> students = new List<Student>
        {
            new Student("Тест1", "Тестов", "Тестович", "Россия", 1, "105", "Тестовая", "Тестовое", new Passport(1234567890), new Visa(0987654321, new DateTime(1,2,3))),
            new Student("Тест2", "Тестов", "Тестович", "Россия", 2, "205", "Тестовая", "Тестовое", new Passport(1234567890), new Visa(0987654321, new DateTime(1,2,3))),
            new Student("Тест3", "Тестов", "Тестович", "Россия", 3, "305", "Тестовая", "Тестовое", new Passport(1234567890), new Visa(0987654321, new DateTime(1,2,3))),
            new Student("Тест4", "Тестов", "Тестович", "Россия", 4, "405", "Тестовая", "Тестовое", new Passport(1234567890), new Visa(0987654321, new DateTime(1,2,3))),
            new Student("Тест5", "Тестов", "Тестович", "Россия", 5, "505", "Тестовая", "Тестовое", new Passport(1234567890), new Visa(0987654321, new DateTime(1,2,3))),
        };

        public ViewResult Students()
        {
            return View(students);
        }

        [HttpPost]
        public JsonResult GetInfo(int id)
        {
            Student student;
            try
            {
                student = students[id];
            }
            catch (ArgumentOutOfRangeException)
            {
                student = null;
            }
            return Json(student);
        }
    }
}
