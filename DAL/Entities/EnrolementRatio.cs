using Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
    public class EnrolementRatio : BaseEntity
    {
        [JsonProperty("total_net_enrolment_rate")]
        [JsonPropertyName("total_net_enrolment_rate")]
        public string EnrolementRate { get; set; }
        
        [JsonProperty("level_of_education")]
        [JsonPropertyName("level_of_education")]
        public string EducationLevel { get; set; }

        public string Sex { get; set; }
        public string Year { get; set; }
    }
}
