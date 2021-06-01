using System;
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
        public IActionResult Main(int? month, int? year)
        {

            month ??= DateTime.Today.Month;
            year ??= DateTime.Today.Year;

            var url =
                $"https://script.google.com/macros/s/AKfycbxTnujwWVsKv2nmfWoAbafq5JFK4EVjVhmigGf0AqPu5anv_0oVo4O2Wa8OBMI-5ey_Mw";
            RestClient client = new RestClient(url);
            var request = new RestRequest("exec", DataFormat.Json);
            request.AddParameter("month", month.Value);
            request.AddParameter("year", year.Value);
            var timeline = client.Execute(request);
            JObject completeJObject = JObject.Parse(timeline.Content);
            var results = completeJObject["body"]["dates"].Children().ToList();
            var stringResults = JsonConvert.SerializeObject(results);
            var modelData = JsonConvert.DeserializeObject<List<ZoomUsageModelData>>(stringResults);
            var modelReseults = new ZoomUsageModel(year.Value, month.Value)
            {
                Month = (MonthOfYear)month,
                Year = year.Value,
                ZoomData = modelData

            };

            return View(modelReseults);
        }

        public IActionResult Minor()
        {

            return View();
        }

    }
}
