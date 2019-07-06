using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MarjamPrism.Models
{
    class LocationResults
    {

        [JsonProperty("stores")]
        public List<Store> Stores { get; set; }


    }
}
