using BeautyBookAdminApp.Models;
using BeautyBookAdminApp.Services;
using BeautyBookAdminApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeautyBookAdminApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSercivesPage : ContentPage
    {
        ObservableRangeCollection<Service> services;
        Service service;
        SalonInformationModel salonModel = new SalonInformationModel();
        Database _userDB = new Database();

        public AddSercivesPage()
        {
            InitializeComponent();
            services = new ObservableRangeCollection<Service>();
            serviceListView.ItemsSource = services;

        }

        public async void OnAddServiceClicked(object sender, System.EventArgs e)
        {
            string text = serviceNameEntry.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                ServicesFrame.BorderColor = Color.FromHex("#FF5A5A");
                errorMessage.IsVisible = true;
                errorMessage.Text = "* Invalid input, please enter text";
                return;
            } 
            else if (!string.IsNullOrWhiteSpace(text))
            {
                errorMessage.IsVisible = false;
                ServicesFrame.BorderColor = Color.Transparent;
            }
            service = new Service{ Name = serviceNameEntry.Text };
            if (!services.Contains(service))
            {
                services.Add(service);
            }
            serviceNameEntry.Text = "";

            

            var salonServiceLable = this.FindByName<Label>("SalonServiceLable");
            salonServiceLable.IsVisible = true;
        }

        public void OnDeleteServiceClicked(object sender, System.EventArgs e)
        {
            var imageButton = sender as ImageButton;
            var service = imageButton.CommandParameter as Service;
            services.Remove(service);

            if (services.Count == 0)
            {
                var salonServiceLable = this.FindByName<Label>("SalonServiceLable");
                salonServiceLable.IsVisible = false;
            }
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            string salonId = await SecureStorage.GetAsync("salonId");
            var Myservices=await _userDB.GetSalonServices(salonId);
            services.AddRange(Myservices);
        }
        private async void OnSaveClicked(object sender, EventArgs e)
        {

            string salonId = await SecureStorage.GetAsync("oauth_token");
            bool isSave = await _userDB.AddSalonServices( salonId , services);
            if (isSave)
            {
                await DisplayAlert("Added services", "Services saved successfully", "ok");
            }
            else
            {
                await DisplayAlert("Services are not saved", "Failed to save services", "ok");
            }

        }

    }
}