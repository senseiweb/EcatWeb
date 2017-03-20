using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ecat.WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult PassThrough()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}