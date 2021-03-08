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
        }

        [HttpPost]
        public bool Login(string login, string password)
        {
            if (login == "1" && password == "2")
                return true;
            return false;
        }
    }
}