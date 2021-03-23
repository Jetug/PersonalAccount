using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Models;
using PersonalAccount.Models.Entities;
using PersonalAccount.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PersonalAccount.Controllers
{
    public class AccountController : Controller
    {
        readonly List<Student> students = new List<Student>
        {
            new Student("Тест1", "Тестов", null, "Россия", 1, "105", "Тестовая", "Тестовое", new Passport("1234567890"), new Visa(0987654321, new DateTime(18,2,3), new DateTime(22,2,3))),
            new Student("Тест2", "Тестов", null, "Россия", 2, "205", "Тестовая", "Тестовое", new Passport("1234567890"), new Visa(0987654321, new DateTime(18,2,3), new DateTime(22,2,3))),
            new Student("Тест3", "Тестов", "Тестович", "Украина", 3, "305", "Тестовая", "Тестовое", new Passport("1234567890"), new Visa(0987654321, new DateTime(18,2,3), new DateTime(22,2,3))),
            new Student("Тест4", "Тестов", "Тестович", "Россия", 4, "405", "Тестовая", "Тестовое", new Passport("1234567890"), new Visa(0987654321, new DateTime(18,2,3), new DateTime(22,2,3))),
            new Student("Тест5", "Тестов", "Тестович", "Россия", 5, "505", "Тестовая", "Тестовое", new Passport("1234567890"), new Visa(0987654321, new DateTime(18,2,3), new DateTime(22,2,3))),
        };

        public AccountController()
        {
            for(int i = 1; i <= 100; i++)
            {
                students.Add(new Student($"Тест{i}", $"Тестов{i}", $"Тестович{i}", "Россия", 1, "105", "Тестовая", "Тестовое", new Passport("1234567890"), new Visa(0987654321, new DateTime(18, 2, 3), new DateTime(22, 2, 3))));
            }
        }

        //[Authorize]
        public ViewResult Students()
        {
            return  View(students);
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

        [HttpPost]
        public JsonResult Search(string line)
        {
            students.Select((s) =>
            {
                string data = s.Name + s.Surname + s.Patronymic;
                return Searcher.IsMatch(data, line);
            });

            return Json(students[1]);
        }

        [Authorize]
        [HttpGet]
        public async Task<FileResult> DownloadPassport()
        {
             return await Download("wwwroot/Data/Documents/Passports/Паспорт.pdf", "Паспорт.pdf");
        }

        [Authorize]
        [HttpGet]
        public async Task<FileResult> DownloadVisa()
        {
            return await Download("wwwroot/Data/Documents/Visas/Виза.pdf", "Виза.pdf");
        }

        [Authorize]
        [HttpGet]
        public async Task<FileResult> DownloadContract()
        {
            return await Download("wwwroot/Data/Documents/Contracts/Договор.pdf", "Договор.pdf");
        }

        private async Task<FileResult> Download(string path, string name)
        {
            return await Task.Run(() =>
            {
                FileContentResult file = null;
                try
                {
                    byte[] fileBytes = System.IO.File.ReadAllBytes(path);
                    file = File(fileBytes, "application/force-download", name);
                }
                catch (FileNotFoundException)
                {
                    var feature = (IHttpRequestLifetimeFeature)HttpContext.Features[typeof(IHttpRequestLifetimeFeature)];
                    feature.Abort();
                }
                return file;
        });
        }
    }
}
