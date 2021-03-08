using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Data.Models.Entities;
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
            new Student("Тест1", "Тестов", "Тестович", "Россия", 1, "Тестовая", "Тестовое"),
            new Student("Тест2", "Тестов", "Тестович", "Россия", 2, "Тестовая", "Тестовое"),
            new Student("Тест3", "Тестов", "Тестович", "Россия", 3, "Тестовая", "Тестовое"),
            new Student("Тест4", "Тестов", "Тестович", "Россия", 4, "Тестовая", "Тестовое"),
            new Student("Тест5", "Тестов", "Тестович", "Россия", 5, "Тестовая", "Тестовое"),
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
