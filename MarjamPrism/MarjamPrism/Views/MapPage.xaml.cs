using System;
using System.Collections.Generic;
using MarjamPrism.Services;
using Prism.Events;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MarjamPrism.Views
{
    public partial class MapPage : ContentPage
    {
        private IEventAggregator _eventAggregator;
        public MapPage(IEventAggregator eventAggregator)
        {
            InitializeComponent();

            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<UpdateMapPins>().Subscribe(LoadPins);

        }

        private void LoadPins(List<Pin> obj)
        {

            foreach (var item in obj)
            {
                MyMap.Pins.Add(item);
            }

            

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(33.9441, -118.397594), Distance.FromMiles(20)));
        }
    }
}
