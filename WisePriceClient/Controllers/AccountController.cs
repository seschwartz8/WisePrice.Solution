using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WisePriceClient.Models;

namespace WisePriceClient.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
          return View();
        }

        public IActionResult Login()
        {
          return View();
        }

        public IActionResult Register()
        {
          return View();
        }
    }
}