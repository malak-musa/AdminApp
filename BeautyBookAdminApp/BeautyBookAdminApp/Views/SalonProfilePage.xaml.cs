﻿using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeautyBookAdminApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalonProfilePage : ContentPage
    {
        public SalonProfilePage()
        {
            InitializeComponent();
        }

        private async void EditInformation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditInfromationProfilePage());
        }
    }
}