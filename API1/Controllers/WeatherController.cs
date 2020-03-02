using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API1.Models;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://forecast.weather.gov");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");

            var response = await client.GetAsync("MapClick.php?lat=42.335780&lon=-83.0479732&FcstType=json");
            var weather = await response.Content.ReadAsAsync<Weather>();

            return View(weather);
        }
    }
}