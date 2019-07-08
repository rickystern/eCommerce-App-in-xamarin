using MarjamPrism.Models;
using MarjamPrism.Views;
using Newtonsoft.Json;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace MarjamPrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _searchString;
        public string SearchString

        {
            get { return _searchString; }
            set { SetProperty(ref _searchString, value); }
        }
        private PermissionStatus status;
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { SetProperty(ref _selectedProduct, value); }
        }
        private string _text;
        
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        public DelegateCommand ItemSelectedCommand { get; }

        public DelegateCommand SearchCommand { get; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Home";
            ItemSelectedCommand = new DelegateCommand(async () => await ProductSelectedHandler());
            SearchString = "";
            SearchCommand = new DelegateCommand(async () => await SearchHandlerAsync());

        }

        private async Task SearchHandlerAsync()
        {
            var resp = await new HttpClient().GetStringAsync("https://api.bestbuy.com/v1/products((search="+SearchString+ "))?apiKey=wgd9fp6cujtdn27wm9k8rtdg&sort=regularPrice.dsc&show=image,name,regularPrice,sku,shortDescription,inStoreAvailability,manufacturer&pageSize=30&format=json");

            var bestBuyResult = JsonConvert.DeserializeObject<BestBuyResult>(resp);


            Products = new ObservableCollection<Product>(bestBuyResult.Products);
            foreach (var item in Products)
            {
                item.Name = item.Name.Substring(0, item.Name.Length/2) + "...";
                item.RegularPrice = "$" + item.RegularPrice;
                if (item.InStoreAvailability == "true")
                {
                    item.InStoreAvailability = "In Stock";
                }

                else
                {
                    item.InStoreAvailability = "Out of Stock";
                }

            }
        }

        private async Task ProductSelectedHandler()
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add(NavParamKeys.PRODUCT_NAV_KEY, (Object) SelectedProduct);
            await NavigationService.NavigateAsync(nameof(DetailsPage), navigationParams);
        }

        async void getlaptops()
        {

            var resp = await new HttpClient().GetStringAsync("https://api.bestbuy.com/v1/products((categoryPath.id=abcat0502000))?apiKey=wgd9fp6cujtdn27wm9k8rtdg&sort=regularPrice.dsc&show=image,inStoreAvailability,manufacturer,regularPrice,shortDescription,name,sku&pageSize=30&format=json");
            //var resp = await new HttpClient().GetStringAsync("https://api.bestbuy.com/v1/products((categoryPath.id=abcat0204000))?apiKey=wgd9fp6cujtdn27wm9k8rtdg&sort=regularPrice.dsc&show=image,name,regularPrice,sku,shortDescription,inStoreAvailability,manufacturer&pageSize=30&format=json");
            //var resp = await new HttpClient().GetStringAsync("https://api.bestbuy.com/v1/products((search=laptop))?apiKey=wgd9fp6cujtdn27wm9k8rtdg&sort=regularPrice.dsc&show=image,name,regularPrice,sku,shortDescription,inStoreAvailability,manufacturer&format=json");

            var bestBuyResult = JsonConvert.DeserializeObject<BestBuyResult>(resp);

            
            Products = new ObservableCollection<Product>(bestBuyResult.Products);
            foreach (var item in Products)
            {
                item.Name = item.Name.Substring(0, item.Name.Length / 2) + "...";
                item.RegularPrice = "$" + item.RegularPrice;
                if (item.InStoreAvailability == "true")
                {
                    item.InStoreAvailability = "In Stock";
                }

                else
                {
                    item.InStoreAvailability = "Out of Stock";
                }

            }

        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            getlaptops();
            
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
            GetLocationPermission();

        }


        private async void GetLocationPermission()
        {
            if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
            {
                // This is not the actual permission request

            }

            // This is the actual permission request
            var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
            if (results.ContainsKey(Permission.LocationWhenInUse))
                status = results[Permission.LocationWhenInUse];
        }

    }
}
