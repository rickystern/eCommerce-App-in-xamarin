using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarjamPrism.ViewModels
{
    public class CartPageViewModel : ViewModelBase
    {
        public CartPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
