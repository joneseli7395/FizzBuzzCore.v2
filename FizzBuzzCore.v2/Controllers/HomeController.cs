using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FizzBuzzCore.v2.Models;

namespace FizzBuzzCore.v2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Solve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solve(string userIn1, string userIn2)
        {
            var fizzBuzzModel = new FizzBuzz();
            fizzBuzzModel.Fizz = Convert.ToInt32(userIn1);
            fizzBuzzModel.Buzz = Convert.ToInt32(userIn2);

            var output = "";
            for (int i = 1; i <= 100; i++)
            {
                if (i % fizzBuzzModel.Fizz == 0 && i % fizzBuzzModel.Buzz == 0)
                {
                    output += "FizzBuzz, ";
                }
                else if (i % fizzBuzzModel.Fizz == 0)
                {
                    output += "Fizz, ";
                }
                else if (i % fizzBuzzModel.Buzz == 0)
                {
                    output += "Buzz, ";
                }
                else
                {
                    output += i + ", ";
                }
            }

            fizzBuzzModel.Output = output;
            return RedirectToAction("Result", fizzBuzzModel);
        }


        public IActionResult Result(FizzBuzz model)
        {
            return View(model);
        }

        public IActionResult Code()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
