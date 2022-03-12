using Aula13a.Models;
using Aula13b.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aula13b.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _APIserver;
        private readonly HttpClient _InternalClient;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _APIserver = configuration.GetSection("WebAPIServers")
                .GetSection("Class13API").Value;
            _InternalClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage message = await _InternalClient
                .GetAsync(_APIserver + "/api/continents");

            string body = await message.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<Continent>>(body);

            return View(list);
        }

        public async Task<IActionResult> Countries()
        {
            HttpResponseMessage message = await _InternalClient
                .GetAsync(_APIserver + "/api/countries");

            string body = await message.Content.ReadAsStringAsync();

            var lista = JsonConvert.DeserializeObject<List<Country>>(body);

            return View(lista);
        }

        public async Task<IActionResult> CreateCountry()
        {
            HttpResponseMessage message = await _InternalClient
                .GetAsync(_APIserver + "/api/continents");

            string body = await message.Content.ReadAsStringAsync();

            ViewBag.ContinentId = new SelectList(
                JsonConvert.DeserializeObject<List<Continent>>(body),
                "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry(Country country)
        {
            if(ModelState.IsValid)
            {
                HttpContent data = new StringContent(
                    JsonConvert.SerializeObject(country, Formatting.Indented),
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage msg = await _InternalClient
                    .PostAsync(_APIserver + "/api/countries/", data);

                return RedirectToAction("Countries");
            }

            HttpResponseMessage message = await _InternalClient
                .GetAsync(_APIserver + "/api/continents");

            string body = await message.Content.ReadAsStringAsync();

            ViewBag.ContinentId = new SelectList(
                JsonConvert.DeserializeObject<List<Continent>>(body),
                "Id", "Name");

            return View(country);
        }

        public async Task<IActionResult> EditCountry(int id)
        {
            HttpResponseMessage message = await _InternalClient
                .GetAsync(_APIserver + "/api/continents");

            string body = await message.Content.ReadAsStringAsync();

            ViewBag.ContinentId = new SelectList(
                JsonConvert.DeserializeObject<List<Continent>>(body),
                "Id", "Name");

            message = await _InternalClient
                .GetAsync(_APIserver + "/api/countries/" + id);
            body = await message.Content.ReadAsStringAsync();
            Country country = JsonConvert.DeserializeObject<Country>(body);

            return View(country);
        }

        [HttpPost]
        public async Task<IActionResult> EditCountry(int id, Country country)
        {
            HttpClient client = new HttpClient();

            if(ModelState.IsValid)
            {
                // convert object to JSON
                HttpContent data = new StringContent(
                    JsonConvert.SerializeObject(country, Formatting.Indented),
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage msg = await client
                    .PutAsync(_APIserver + "/api/countries/" + id, data);

                return RedirectToAction("Countries");
            }

            HttpResponseMessage message = await _InternalClient
                .GetAsync(_APIserver + "/api/continents");

            string body = await message.Content.ReadAsStringAsync();

            ViewBag.ContinentId = new SelectList(
                JsonConvert.DeserializeObject<List<Continent>>(body),
                "Id", "Name");

            return View(country);
        }

        public async Task<IActionResult> DeleteCountry(int id)
        {
            HttpResponseMessage message = await _InternalClient
                .DeleteAsync(_APIserver + "/api/countries/" + id);

            if(message.StatusCode == HttpStatusCode.OK)
            {
                TempData["msgResult"] = "Country successfully deleted";
            }

            return RedirectToAction("Countries");
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
