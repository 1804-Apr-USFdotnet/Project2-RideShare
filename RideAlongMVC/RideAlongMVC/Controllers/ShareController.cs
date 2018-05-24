using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using RideAlongMVC.Models;
using Newtonsoft.Json;

namespace RideAlongMVC.Controllers
{
    public class ShareController : Controller
    {

        string WebAPIURL = "http://ec2-18-191-50-192.us-east-2.compute.amazonaws.com/RideAlongAPI";
        // GET: Share
        public ActionResult Index()
        {
            List<Share> shares = new List<Share>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebAPIURL);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var task = client.GetAsync("api/Shares");
                task.Wait();

                HttpResponseMessage Res = task.Result;

                if(Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;

                    shares = JsonConvert.DeserializeObject<List<Share>>(response);
                    
                }
            }

                return View(shares);
        }
    }
}