using System.Collections.Generic;
using System.Linq;
using CommonPeril.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace CommonPeril.Controllers
{
    public class HomeController : Controller
    {
       
       
        public HomeController()
        {
           
            
        }
        public IActionResult Main()
        {
            RestClient client = new RestClient("https://script.google.com/macros/s/AKfycbxTnujwWVsKv2nmfWoAbafq5JFK4EVjVhmigGf0AqPu5anv_0oVo4O2Wa8OBMI-5ey_Mw");
            var request = new RestRequest("exec", DataFormat.Json);
            var timeline = client.Execute(request);
            JObject completeJObject = JObject.Parse(timeline.Content);
            var results = completeJObject["body"]["dates"].Children().ToList();
            var stringResults = JsonConvert.SerializeObject(results);
            var modelReseults = JsonConvert.DeserializeObject<List<ZoomUsageModel>>(stringResults);

            return View(modelReseults);
        }

        public IActionResult Minor()
        {

            return View();
        }

    }
}
