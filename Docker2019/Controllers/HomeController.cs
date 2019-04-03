using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Docker2019.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Docker2019.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            string countri="";
            IEnumerable<string> listCountries;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55552/");
            // Add an Accept header for JSON format.    
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.    
            HttpResponseMessage response = client.GetAsync("api/Values/TraerDatos/").Result;
            if (response.IsSuccessStatusCode)
            {
                countri = response.Content.ReadAsStringAsync().Result;
            }
            listCountries = JsonConvert.DeserializeObject<IEnumerable<string>>(countri);
            return View(listCountries);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
