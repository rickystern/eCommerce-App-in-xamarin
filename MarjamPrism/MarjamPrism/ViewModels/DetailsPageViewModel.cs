﻿using MarjamPrism.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

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

        private string _image;
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

       

        public DetailsPageViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "CartPage";
            Name = "Nuh Get ntn";
        }

        public  override void OnNavigatingTo(INavigationParameters parameters)
        {
            
            try
            {
                Laptop = parameters[NavParamKeys.PRODUCT_NAV_KEY] as Product;
                Name = Laptop.Name;
                Image = Laptop.Image;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
