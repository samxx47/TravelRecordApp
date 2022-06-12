using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;

using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {

            InitializeComponent();

           
            //Position position = new Position(36.9628066, -122.0194722);
            //MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            //Map map = new Map(mapSpan)
            //{
            //    MapType = MapType.Satellite
            //};
            //Content = map;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetLocation();
        }

        private async void GetLocation()
        {
            var status = await ChaeckAndRequestLocationPermissionAsync();
            if(status == PermissionStatus.Granted)
            {
                var location =await  Geolocation.GetLastKnownLocationAsync();
            }
        }

        private async Task<PermissionStatus> ChaeckAndRequestLocationPermissionAsync()
        {
           var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status == PermissionStatus.Granted)
                return status;

            if(status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                //promt the user to turn on the permissions in the settings
                return status;
            }

            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return status;


        }
    }
}