using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Controllers
{
    public class AccountController: Controller
    {
        public ViewResult List()
        {
            List<int> nums = new List<int>{1, 2, 3, 4, 5};
            return View(nums);
        }

        public ViewResult Info()
        {
            return View();
        }
    }
}
