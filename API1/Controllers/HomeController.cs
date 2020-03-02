using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using API1.Models;

namespace API1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //asynchronous controller actions return tasks
        //the task provides in this case the IAction Result (the view)
        //when everything's done
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.icndb.com");

            var response = await client.GetAsync("jokes/random");
            var joke = await response.Content.ReadAsAsync<Joke>();

            ViewBag.Response = joke;

            return View(joke);
        }

        public async Task<IActionResult> ListJokes()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.icndb.com");

            var response = await client.GetAsync("jokes/random/10");
            var joke = await response.Content.ReadAsAsync<JokeList>();

            ViewBag.Response = joke;

            return View(joke);
        }


        public IActionResult Privacy()
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
