using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalAccount.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc.Ajax;

namespace PersonalAccount.Controllers
{
    public class TestController : Controller
    {
        public ViewResult TestView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BookSearch(string name)
        {
            var allbooks = new List<Book> { new Book(1, "test", "tester", 42) };
            //Ajax.BeginForm()
            return PartialView(allbooks);
        }
    }
}
