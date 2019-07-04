using Plugin.Permissions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MarjamPrism.ViewModels
{
    public class MapPageViewModel : ViewModelBase
    {
        private Position _position;
        public Position Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }
        public MapPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Position = new Position(47.6370891183, -122.123736172);
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {

            Position = new Position(47.6370891183, -122.123736172);


        }
 
        
    }
}
