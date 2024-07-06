using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> cw = new List<CityWeather>()
            {
                new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"),  TemperatureFahrenheit = 33},
                new CityWeather() { CityUniqueCode = "NYC", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
                new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"),  TemperatureFahrenheit = 82}
            };
            return View("Index", cw); //Views/Weather/Index.cshtml
        }

        [Route("/weather/{cityCode}")]
        public IActionResult Details(string? cityCode)
        {
            if(cityCode == null)
            {
                return Content("City code cannot be null.");
            }

            List<CityWeather> cw = new List<CityWeather>()
            {
                new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"),  TemperatureFahrenheit = 33},
                new CityWeather() { CityUniqueCode = "NYC", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
                new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"),  TemperatureFahrenheit = 82}
            };

            CityWeather? matchingCity = cw.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault();
            return View("Views/Weather/Details.cshtml",matchingCity); //Views/Weather/Details.cshtml
        }
    }
}
