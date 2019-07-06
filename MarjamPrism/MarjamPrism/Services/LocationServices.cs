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
                //var resp = await new HttpClient().GetStringAsync("https://api.bestbuy.com/v1/stores((region=NY))+products(sku%20in%20(" + qsku + "))?apiKey=wgd9fp6cujtdn27wm9k8rtdg&show=products.sku,products.name,products.shortDescription,products.salePrice,products.regularPrice,products.addToCartURL,products.url,products.image,products.customerReviewCount,products.customerReviewAverage,address,phone,name,lng,lat,city&format=json");
                var resp = await new HttpClient().GetStringAsync("https://api.bestbuy.com/v1/stores((region=NY))+products?apiKey=wgd9fp6cujtdn27wm9k8rtdg&show=products.sku,products.name,products.shortDescription,products.salePrice,products.regularPrice,products.addToCartURL,products.url,products.image,products.customerReviewCount,products.customerReviewAverage,address,phone,name,lng,lat,city&format=json");

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
