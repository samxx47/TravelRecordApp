﻿using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();
            var locator = CrossGeolocator.Current;
            //var position =await locator.GetPositionAsync();
            
            //var venues = VenueLogic.GetVenus(position.Latitude , position.Longitude);
            var venues = VenueLogic.GetVenus();
            venueListView.ItemsSource=venues;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Post post = new Post()
            {
                Experience = experienceEntry.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(post);
                

                if (rows > 0)
                {
                    DisplayAlert("Success", "experience succesfullt added", "OK");
                }
                else
                {
                    DisplayAlert("Failure", "experience failed to added", "OK");
                }

            }
           
            

        }
    }
}