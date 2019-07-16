using MarjamPrism.Models;
using MarjamPrism.ViewModels;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarjamPrism.Services
{
    public class ProductServices : IProductServices
    {
       

        public async Task<ObservableCollection<Product>> GetProducts()
        {
            try
            {
                //var resp = await new HttpClient().GetStringAsync("BaseUrl.BASE_URL+"products((categoryPath.id=abcat0502000))?apiKey=wgd9fp6cujtdn27wm9k8rtdg&sort=regularPrice.dsc&show=image,inStoreAvailability,manufacturer,regularPrice,shortDescription,name,sku&pageSize=30&format=json");
                //var resp = await new HttpClient().GetStringAsync(BaseUrl.BASE_URL+"products((categoryPath.id=abcat0204000))?apiKey=wgd9fp6cujtdn27wm9k8rtdg&sort=regularPrice.dsc&show=image,name,regularPrice,sku,shortDescription,inStoreAvailability,manufacturer&pageSize=30&format=json");
                //var resp = await new HttpClient().GetStringAsync(BaseUrl.BASE_URL+"products((search=laptop))?apiKey=wgd9fp6cujtdn27wm9k8rtdg&sort=regularPrice.dsc&show=image,name,regularPrice,sku,shortDescription,inStoreAvailability,manufacturer&format=json");
                var resp = await new HttpClient().GetStringAsync(BaseUrl.BASE_URL+"products(onSale=true)?apiKey=wgd9fp6cujtdn27wm9k8rtdg&sort=regularPrice.dsc&show=image,name,regularPrice,sku,shortDescription,inStoreAvailability,manufacturer&pageSize=20&format=json");

                var bestBuyResult = JsonConvert.DeserializeObject<BestBuyResult>(resp);
                ObservableCollection<Product> Products = new ObservableCollection<Product>(bestBuyResult.Products);
                foreach (var item in Products)
                {
                    item.RegularPrice = "$" + item.RegularPrice;
                    if (item.InStoreAvailability == "true")
                    {
                        item.InStoreAvailability = "In Stock";
                    }

                    else
                    {
                        item.InStoreAvailability = "Out of Stock";
                    }
                    if (item.Image == null)
                    {
                        item.Image = "https://www.modvellumclinical.com/wp-content/uploads/no-product-image.png";
                    }
                    if (item.ShortDescription == null)
                    {
                        item.ShortDescription = "No description available";
                    }

                }

                return Products;
            }
            catch (Exception e)
            {

                throw e;
            }

            
        }
    }
}
