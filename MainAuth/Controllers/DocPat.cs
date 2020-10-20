using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MainAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MainAuth.Controllers
{
    public class DocPat : Controller
    {
        public IActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44319/api/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("Doctors").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<IEnumerable<Doctor>>(stringData);
                return View(data);
            }
        }

        public IActionResult Patient()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44319/api/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("Patients").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<IEnumerable<Patient>>(stringData);
                return View(data);
            }
        }

    }
}
