using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarjamPrism.ViewModels
{
    class BestBuyResult
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }


    }
}