using MarjamPrism.Models;
using MarjamPrism.Services;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace MarjamPrism.ViewModels
{
    public class MapPageViewModel : ViewModelBase
    {

        private IEventAggregator _eventAggregator;
        private ILocationServices _locationService;

        private List<Pin> LocationPins = new List<Pin>();


        private List<Store> _stores;
        public List<Store> Stores
        {
            get { return _stores; }
            set { SetProperty(ref _stores, value); }
        }

        private Pin Pin = new Pin();

        private string _sku;
        public string SKU
        {
            get { return _sku; }
            set { SetProperty(ref _sku, value); }
        }

        private Product _laptop;
        public Product Laptop
        {
            get { return _laptop; }
            set { SetProperty(ref _laptop, value); }
        }
        public MapPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator, ILocationServices locationservice) : base(navigationService)
        {
            _eventAggregator = eventAggregator;
            _locationService = locationservice;


        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            
                Laptop = parameters[NavParamKeys.PRODUCT_NAV_KEY] as Product;
                SKU = Laptop.SKU;
                await getLocations(SKU);
            try
            {
                createPins();
            }
            catch (Exception e)
            {

                throw e;
            }  

        }

        private void createPins()
        {
            foreach (var item in Stores)
            {


                Pin.Position = new Position(item.Lat, item.Lng);
                Pin.Label = item.Name;
                Pin.Address = item.Address;

                LocationPins.Add(Pin); // this line throwing error below

                //at MarjamPrism.ViewModels.MapPageViewModel.createPins () [0x00053] in C:\Users\ShakeaneHinds\Desktop\Xamarin Compare\MarjamPrism\MarjamPrism\MarjamPrism\ViewModels\MapPageViewModel.cs:85 
                //at MarjamPrism.ViewModels.MapPageViewModel.OnNavigatingTo(Prism.Navigation.INavigationParameters parameters)[0x000bd] in C: \Users\ShakeaneHinds\Desktop\Xamarin Compare\MarjamPrism\MarjamPrism\MarjamPrism\ViewModels\MapPageViewModel.cs:62


            }

            var a = LocationPins.Count;
        }

        public async Task getLocations(string SKU)
        {
 
                Stores = await _locationService.getStores(SKU);

        }

        
    }
}
