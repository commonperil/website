using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CommonPeril.Models
{
    public class ZoomUsageModel
    {
        
        public ZoomUsageModel(int year, int month)
        {
            YearList = Enumerable.Range(0, (DateTime.Now.Year - 2020)).Select(i => new SelectListItem
                {Text = (DateTime.Now.Year - i).ToString(), Value = (DateTime.Now.Year - i).ToString(), Selected = i==year?true:false}).ToList();
            //MonthList = new List<SelectListItem>(Enum.GetValues(typeof(MonthOfYear)).Select(c => new SelectListItem() { Value = (int)c, Name = c.ToString() })
            MonthList = ((MonthOfYear[]) Enum.GetValues(typeof(MonthOfYear))).Select(c => new SelectListItem()
                {Value = Convert.ToInt32(c).ToString(), Text = c.ToString(), Selected = Convert.ToInt32(c)==month?true:false}).ToList();


        }
        public List<ZoomUsageModelData> ZoomData { get; set; }
        public MonthOfYear Month { get; set; }
        public int Year { get; set; }
        public List<SelectListItem> YearList { get; set; }
        public List<SelectListItem> MonthList { get; set; }
        public List<SelectListItem> MonthYear { get; set; }


       
    }

    

    

    public class ZoomUsageModelData
    {
        [DataType(DataType.Date)]
        [JsonProperty("date")]
        public DateTime MeetingDate { get; set; }
        [JsonProperty("day")] public int Day => MeetingDate.Day;

        [JsonProperty("meetings")] public int Meetings { get; set; }
        [JsonProperty("participants")] public int Users { get; set; }
        [JsonProperty("meeting_minutes")] public int TotalMinutes { get; set; }
    }

    public enum MonthOfYear
    {
        
        Jan = 1,
        Feb = 2,
        Mar = 3,
        Apr =4,
        May = 5,
        Jun = 6,
        Jul = 7,
        Aug = 8,
        Sep = 9,
        Oct = 10,
        Nov = 11,
        Dec = 12
    }





}
