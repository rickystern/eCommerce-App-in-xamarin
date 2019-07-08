using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarjamPrism
{
    public class Product: BindableBase
    {
        
        
        private string _image;
        [JsonProperty("image")]
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        
        private string _inStoreAvailability;
        [JsonProperty("inStoreAvailability")]
        public string InStoreAvailability
        {
            get { return _inStoreAvailability; }
            set { SetProperty(ref _inStoreAvailability, value); }
        }
        
        private string _manufaturer;
        [JsonProperty("manufacturer")]
        public string Manufacturer
        {
            get { return _manufaturer; }
            set { SetProperty(ref _manufaturer, value); }
        }


        private string _regularPrice;
        [JsonProperty("regularPrice")]
        public string RegularPrice
        {
            get { return _regularPrice; }
            set { SetProperty(ref _regularPrice, value); }
        }


        private string _shortdescription;
        [JsonProperty("shortDescription")]
        public string ShortDescription
        {
            get { return _shortdescription; }
            set { SetProperty(ref _shortdescription, value); }
        }


        private string _name;
        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _sku;
        [JsonProperty("sku")]
        public string SKU
        {
            get { return _sku; }
            set { SetProperty(ref _sku, value); }
        }
    }
}
