using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarjamPrism.Models
{
    public class Store : BindableBase
    {
        private string _address;

        [JsonProperty("address")]
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }


        private string _city;

        [JsonProperty("city")]
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }

        private float _lat;

        [JsonProperty("lat")]
        public float Lat
        {
            get { return _lat; }
            set { SetProperty(ref _lat, value); }
        }



        private float _lng;

        [JsonProperty("lng")]
        public float Lng
        {
            get { return _lng; }
            set { SetProperty(ref _lng, value); }
        }


        private string _phone;

        [JsonProperty("phone")]
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }

        private string _name;

        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private List<ResProduct> _resProducts;

        [JsonProperty("products")]
        public List<ResProduct> ResProducts
        {
            get { return _resProducts; }
            set { SetProperty(ref _resProducts, value); }
        }

    }
}
