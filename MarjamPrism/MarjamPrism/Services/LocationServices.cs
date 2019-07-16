using MarjamPrism.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarjamPrism.Services
{
    public class LocationServices: ILocationServices
    {

        public async Task<List<Store>> getStores(string qsku)
        {
            LocationResults bestBuyResult;
            try
            {
                //variable not being used because the best buy api has limitations and returns no products when an sku is used unless you set the seasrch radius to 900 miles, absured!
                //var resp = await new HttpClient().GetStringAsync("https://api.bestbuy.com/v1/stores((region=NY))+products(sku%20in%20(" + qsku + "))?apiKey=wgd9fp6cujtdn27wm9k8rtdg&show=products.sku,products.name,products.shortDescription,products.salePrice,products.regularPrice,products.addToCartURL,products.url,products.image,products.customerReviewCount,products.customerReviewAverage,address,phone,name,lng,lat,city&format=json");
                var resp = await new HttpClient().GetStringAsync(BaseUrl.BASE_URL + "stores((region=CA))+products?apiKey=wgd9fp6cujtdn27wm9k8rtdg&show=products.sku,products.name,products.shortDescription,products.salePrice,products.regularPrice,products.addToCartURL,products.url,products.image,products.customerReviewCount,products.customerReviewAverage,address,phone,name,lng,lat,city&format=json");
                //var resp = await new HttpClient().GetStringAsync(BaseUrl.BASE_URL+"stores((area(37,-122,900)))+products(sku%20in%20(" + qsku + "))?apiKey=wgd9fp6cujtdn27wm9k8rtdg&show=products.sku,products.name,products.shortDescription,products.salePrice,products.regularPrice,products.addToCartURL,products.url,products.image,products.customerReviewCount,products.customerReviewAverage,address,phone,name,lng,lat,city&format=js");
                bestBuyResult = JsonConvert.DeserializeObject<LocationResults>(resp);

                
            }
            catch (Exception e)
            {

                throw e;
            }

            return bestBuyResult.Stores;

        }

        
    }
}
