using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Models
{
    public class TestModel
    {
        //   [JsonProperty(PropertyName = "I")]
        public long Id { get; set; }

        //  [JsonProperty(PropertyName = "N")]
        public string Name { get; set; }

        //    [JsonProperty(PropertyName = "M")]
        public decimal Money { get; set; }

        //    [JsonProperty(PropertyName = "IE")]
        public bool IsEnable { get; set; }

        //     [JsonProperty(PropertyName = "CD")]
        public DateTime CreateDate { get; set; }

        //    [JsonProperty(PropertyName = "UD")]
        public DateTime? UpdateDate { get; set; }
    }
}