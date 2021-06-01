using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CommonPeril.Models
{
    public class ZoomUsageModel
    {
        [DataType(DataType.Date)]
        [JsonProperty("date")]
        public DateTime MeetingDate { get; set; }
        [JsonProperty("meetings")]
        public int Meetings { get; set; }
        [JsonProperty("participants")]
        public int Users { get; set; }
        [JsonProperty("meeting_minutes")]
        public int TotalMinutes { get; set; }
    }
}
