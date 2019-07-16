using MarjamPrism.Models;
using MarjamPrism.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarjamPrism.Services
{
    public class SearchService: ISearchService
    {
        public async Task<ObservableCollection<Product>> GetSearchResults(string SearchString)
        {
            try
            {
                var resp = await new HttpClient().GetStringAsync(BaseUrl.BASE_URL+"products((search=" + SearchString + "))?apiKey=wgd9fp6cujtdn27wm9k8rtdg&sort=regularPrice.dsc&show=image,name,regularPrice,sku,shortDescription,inStoreAvailability,manufacturer&pageSize=30&format=json");

                var bestBuyResult = JsonConvert.DeserializeObject<BestBuyResult>(resp);
                ObservableCollection<Product> Products = new ObservableCollection<Product>(bestBuyResult.Products);
                foreach (var item in Products)
                {
                    //item.Name = item.Name.Substring(0, item.Name.Length/2) + "...";
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
