using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Data.Models
{
    public class HomeController: Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
            //return Redirect("~/Account/List");
        }

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            string authData = $"Login: {login}   Password: {password}";
            //return Content(authData);
            return Redirect("~/Account/List");
        }

        public IActionResult Check(string button)
        {
            //TempData["buttonval"] = "clicked";
            //return RedirectToAction("Index");
            return Redirect("~/Account/List");
        }

        public IActionResult HandleButtonClick(string login, string password)
        {
            string authData = $"Login: {login}   Password: {password}";
            //return Content(authData);
            if(login == "1" && password == "2")
                return Redirect("~/Account/Info");
            return View("Index");
        }
    }
}