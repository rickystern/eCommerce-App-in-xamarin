using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarjamPrism.Models
{
    public class ResProduct: BindableBase
    {
        private string _image;
        [JsonProperty("image")]
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }


        private int _sku;

        [JsonProperty("sku")]
        public int SKU
        {
            get { return _sku; }
            set { SetProperty(ref _sku, value); }
        }

        private decimal _salePrice;

        [JsonProperty("salePrice")]
        public decimal SalePrice
        {
            get { return _salePrice; }
            set { SetProperty(ref _salePrice, value); }
        }


        private decimal _regularPrice;
        [JsonProperty("regularPrice")]
        public decimal RegularPrice
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

        private string _addToCartUrl;

        [JsonProperty("addToCartUrl")]
        public string AddToCartUrl
        {
            get { return _addToCartUrl; }
            set { SetProperty(ref _addToCartUrl, value); }
        }

        private int _customerReviewCount;

        [JsonProperty("customerReviewCount")]
        public int CustomerReviewCount
        {
            get { return _customerReviewCount; }
            set { SetProperty(ref _customerReviewCount, value); }
        }

        private double _customerReviewAverage;
        public double CustomerReviewAverage
        {
            get { return _customerReviewAverage; }
            set { SetProperty(ref _customerReviewAverage, value); }
        }
    }
}
