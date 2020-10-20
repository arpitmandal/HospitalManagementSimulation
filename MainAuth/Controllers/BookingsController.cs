using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MainAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MainAuth.Controllers
{
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
            Users obj = new Users { Email = "admin", Password = "admin" };
            using (HttpClient client = new HttpClient())
            {
                var token = GetToken("https://localhost:44312/api/Token", obj);
                client.BaseAddress = new Uri("https://localhost:44302/api/");
                // MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                //client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("Bookings").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<IEnumerable<Booking>>(stringData);
                return View(data);
            }
        }
        static string GetToken(string url, Users user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, data).Result;
                string name = response.Content.ReadAsStringAsync().Result;
                dynamic details = JObject.Parse(name);
                return details.token;
            }
        }
    }
}
