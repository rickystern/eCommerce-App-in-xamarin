using MarjamPrism.Models;
using MarjamPrism.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarjamPrism.ViewModels
{

    
    public class DetailsPageViewModel : ViewModelBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private Product _laptop;
        public Product Laptop
        {
            get { return _laptop; }
            set { SetProperty(ref _laptop, value); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _sku;
        public string SKU
        {
            get { return _sku; }
            set { SetProperty(ref _sku, value); }
        }

        private string _image;
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        private string _shortDescription;
        public string ShortDescription
        {
            get { return _shortDescription; }
            set { SetProperty(ref _shortDescription, value); }
        }
        public DelegateCommand MapsViewCommand { get; }

        public DetailsPageViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "CartPage";
            Name = "Nuh Get ntn";
            MapsViewCommand = new DelegateCommand(async () => await StoreRequestedHandler());
        }

        private async Task StoreRequestedHandler()
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add(NavParamKeys.PRODUCT_NAV_KEY, (Object)Laptop);
            await NavigationService.NavigateAsync(nameof(MapPage), navigationParams);
        }

        public  override void OnNavigatingTo(INavigationParameters parameters)
        {
            
            try
            {
                Laptop = parameters[NavParamKeys.PRODUCT_NAV_KEY] as Product;
                Name = Laptop.Name;
                Image = Laptop.Image;
                ShortDescription = Laptop.ShortDescription;
                SKU = Laptop.SKU;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
