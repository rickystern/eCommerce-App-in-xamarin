﻿using MarjamPrism.Models;
using MarjamPrism.Views;
using Newtonsoft.Json;
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

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Home";
            ItemSelectedCommand = new DelegateCommand(async () => await ProductSelectedHandler());

        }


        private async Task ProductSelectedHandler()
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add(NavParamKeys.PRODUCT_NAV_KEY, (Object) SelectedProduct);
            await NavigationService.NavigateAsync(nameof(DetailsPage), navigationParams);
        }

        async void getlaptops()
        {

            var resp = await new HttpClient().GetStringAsync("https://api.bestbuy.com/v1/products((categoryPath.id=abcat0502000))?apiKey=wgd9fp6cujtdn27wm9k8rtdg&sort=regularPrice.dsc&show=image,inStoreAvailability,manufacturer,regularPrice,shortDescription,name&pageSize=30&format=json");
            var bestBuyResult = JsonConvert.DeserializeObject<BestBuyResult>(resp);

            
            Products = new ObservableCollection<Product>(bestBuyResult.Products);
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            getlaptops();
            
        }


        


    }
}
