using MarjamPrism.Models;
using MarjamPrism.Services;
using Prism.Events;
using Prism.Navigation;
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
                createPins();
                _eventAggregator.GetEvent<UpdateMapPins>().Publish(LocationPins);
                

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        private void createPins()
        {
            foreach (var item in Stores)
            {

                Pin Position = new Pin();

                Position.Position = new Position(item.Lat, item.Lng);
                Position.Label = item.Name;
                Position.Address = item.Address;

                

                LocationPins.Add(Position); 
            }

            var a = LocationPins.Count;
        }

        public async Task getLocations(string SKU)
        {
 
                Stores = await _locationService.getStores(SKU);

        }

        
    }
}
