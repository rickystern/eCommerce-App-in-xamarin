using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MarjamPrism.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            var pin = new Pin()
            {
                Position = new Position(38, -119),
                Label = "Duck Buy HQ",
                Address = "112 Ducky Street CA"
            };
            var pin1 = new Pin()
            {
                Position = new Position(37, -122),
                Label = "Duck Buy Warehouse",
                Address = "112 Ducky Street CA"

            };
            var pin2 = new Pin()
            {
                Position = new Position(36, -121),
                Label = "Ducky Buy Store",
                Address = "112 Ducky Street CA"
            };

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(20)));
            MyMap.Pins.Add(pin);
            MyMap.Pins.Add(pin1);
            MyMap.Pins.Add(pin2);

        }

    }
}
