using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace MarjamPrism.Services
{
    public class UpdateMapPins : PubSubEvent<List<Pin>> { }
}
