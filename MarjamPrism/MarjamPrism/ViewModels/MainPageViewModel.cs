using MarjamPrism.Models;
using MarjamPrism.Services;
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
        private IProductServices _productService;
        private ISearchService _searchService;

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
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
        private string _header;
        public string Header
        {
            get { return _header; }
            set { SetProperty(ref _header, value); }
        }
        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        public DelegateCommand ItemSelectedCommand { get; }

        public DelegateCommand SearchCommand { get; }

        public DelegateCommand RefreshCommand { get; }

        public MainPageViewModel(INavigationService navigationService, IProductServices productService, ISearchService searchService)
            : base(navigationService)
        {
            Title = "Home";
            ItemSelectedCommand = new DelegateCommand(async () => await ProductSelectedHandler());
            SearchString = "";
            Header = "Top Products";
            IsBusy = false;
            SearchCommand = new DelegateCommand(async () => await SearchHandlerAsync());
            RefreshCommand = new DelegateCommand(async () => await RefreshHandlerAsync());
            _productService = productService;
            _searchService = searchService;

        }

        async Task RefreshHandlerAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
          
            Products = await _productService.GetProducts();
                      
            IsBusy = false;

            SearchString = "";

            Header = "Top Products";



        }

        private async Task SearchHandlerAsync()
        {

            if (!(SearchString == ""))
            {
                    Products = await _searchService.GetSearchResults(SearchString);
            }
            else
            {
                SearchString = "";
            }

            Header = "Results for " + "'" + SearchString + "'";
        }

        private async Task ProductSelectedHandler()
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add(NavParamKeys.PRODUCT_NAV_KEY, (Object) SelectedProduct);
            await NavigationService.NavigateAsync(nameof(DetailsPage), navigationParams);
        }

        async void GetProducts()
        {

            Products = await _productService.GetProducts();
          
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            GetProducts();
            
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
