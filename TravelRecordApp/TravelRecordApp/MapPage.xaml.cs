using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;

using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Position = Xamarin.Forms.Maps.Position;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        IGeolocator locator =CrossGeolocator.Current;
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

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            locator.StopListeningAsync();
            
        }

        private async void GetLocation()
        {
            var status = await ChaeckAndRequestLocationPermissionAsync();
            if(status == PermissionStatus.Granted)
            {
                var location =await  Geolocation.GetLastKnownLocationAsync();

                
                locator.PositionChanged += locator_PositionChanged; 

                await locator.StartListeningAsync(new TimeSpan(0,1,0),100);


                locationsMap.IsShowingUser = true;

                CenterMap(location.Latitude, location.Longitude);
            }
        }

        private void locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            CenterMap(e.Position.Latitude, e.Position.Longitude);
        }

        private void CenterMap(double latitude, double longitude)
        {
            Position center = new Position(latitude, longitude);
            MapSpan span = new MapSpan(center,1,1);



            locationsMap.MoveToRegion(span);
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