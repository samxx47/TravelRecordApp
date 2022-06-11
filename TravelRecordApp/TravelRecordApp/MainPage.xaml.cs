﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
              InitializeComponent();
        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if(isEmailEmpty   || isPasswordEmpty  )
            {
                //do not do navigation
            }

            else
            {
                // do navigation
                Navigation.PushAsync(new HomePage()); 
            }


        }
    }
}
