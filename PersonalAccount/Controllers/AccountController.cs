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
            new Student("Тест1", "Тестов", null,       new DateTime(2001,10,10), "Мужской", "Россия",  "МГУТУ", new Passport("1234567890"), new Visa(0987654321, new DateTime(18,2,3), new DateTime(22,2,3)), new Contract(176453273,new DateTime(2010,2,1))),
            new Student("Тест2", "Тестов", null,       new DateTime(2001,10,10), "Мужской", "Россия",  "МГУТУ", new Passport("1234567890"), new Visa(0987654321, new DateTime(18,2,3), new DateTime(22,2,3)), new Contract(176453273,new DateTime(2010,2,1))),
            new Student("Тест3", "Тестов", "Тестович", new DateTime(2001,10,10), "Женский", "Украина", "МГУТУ", new Passport("1234567890"), new Visa(0987654321, new DateTime(18,2,3), new DateTime(22,2,3)), new Contract(176453273,new DateTime(2010,2,1))),
            new Student("Тест4", "Тестов", "Тестович", new DateTime(2001,10,10), "Женский", "Россия",  "МГУТУ", new Passport("1234567890"), new Visa(0987654321, new DateTime(18,2,3), new DateTime(22,2,3)), new Contract(176453273,new DateTime(2010,2,1))),
            new Student("Тест5", "Тестов", "Тестович", new DateTime(2001,10,10), "Мужской", "Россия",  "МГУТУ", new Passport("1234567890"), new Visa(0987654321, new DateTime(18,2,3), new DateTime(22,2,3)), new Contract(176453273,new DateTime(2010,2,1))),
        };

        public AccountController()
        {
            for (int i = 1; i <= 100; i++)
            {
                students.Add(new Student(
                    $"Тест{i}", $"Тестов{i}", $"Тестович{i}", new DateTime(2001, 10, 10), "Мужской", "Россия", "МГУТУ",
                        new Passport("1234567890"),
                        new Visa(0987654321, new DateTime(18, 2, 3), new DateTime(22, 2, 3)),
                        new Contract(176453273, new DateTime(2010, 2, 1))
                    ));
            }
        }

        //[Authorize]
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
        public FileResult DownloadPassport(int studentId)
        {
            var bytes = FileDownloader.DownloadPassport(studentId);
            return GetFileResult(bytes, "Паспорт.pdf");
        }

        [Authorize]
        [HttpGet]
        public FileResult DownloadVisa(int studentId)
        {
            var bytes = FileDownloader.DownloadVisa(studentId);
            return GetFileResult(bytes, "Паспорт.pdf");
        }

        [Authorize]
        [HttpGet]
        public FileResult DownloadContract(int studentId)
        {
            var bytes = FileDownloader.DownloadContract(studentId);
            return GetFileResult(bytes, "Паспорт.pdf");
        }

        //[Authorize]
        [HttpPost]
        public void UploadPassport(IFormFile file, int studentId)
        {
            if (file != null && isSupportedType(file.ContentType))
            {
                FileUploader.UploadPassport(file, studentId);
            }
        }

        //[Authorize]
        [HttpPost]
        public void UploadVisa(IFormFile file, int studentId)
        {
            if (file != null && isSupportedType(file.ContentType))
            {
                FileUploader.UploadVisa(file, studentId);
            }
        }

        //[Authorize]
        [HttpPost]
        public void UploadContract(IFormFile file, int studentId)
        {
            if (file != null && isSupportedType(file.ContentType))
            {
                FileUploader.UploadContract(file, studentId);
            }
        }

        //[Authorize]
        [HttpGet]
        public string[] GetUploadingDates(int studentId)
        {
            var dates =  new string[]
            {
                DocumentInfo.GetPassportUploadingDate(studentId),
                DocumentInfo.GetVisaUploadingDate(studentId),
                DocumentInfo.GetContractUploadingDate(studentId)
            };
            return dates;
        }

        //[Authorize]
        [HttpGet]
        public string GetUploadingPassportDate(int studentId)
        {
            return DocumentInfo.GetPassportUploadingDate(studentId);
        }

        //[Authorize]
        [HttpGet]
        public string GetVisaUploadingDate(int studentId)
        {
            return DocumentInfo.GetVisaUploadingDate(studentId);
        }

        //[Authorize]
        [HttpGet]
        public string GetContractUploadingDate(int studentId)
        {
            return DocumentInfo.GetContractUploadingDate(studentId);
        }

        [Authorize]
        [HttpPost]
#pragma warning disable CS1998                                                                                                        // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
        public async Task<bool> SaveChanges(Student student)
        {
            return true;
        }
#pragma warning restore CS1998

        private bool isSupportedType(string type) => type == "application/pdf" || type.Substring(0, 5) == "image";

        private FileResult GetFileResult(byte[] fileBytes, string name)
        {
            return File(fileBytes, "application/force-download", name);
        }

        private async Task<FileResult> DownloadAsync(string path, string name)
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
