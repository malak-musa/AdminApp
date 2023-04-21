using BeautyBookCustomerApp.Models;
using Firebase.Auth.Providers;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using beautyBookAdmin.Services;

namespace BeautyBookAdminApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        Database _userDB = new Database();
        private const string FirebaseApiKey = "AIzaSyA37bTpBm27kjiHDuf5tigFwCmVsxmEYsY ";
        private const string FirebaseDatabaseUrl = "https://xamarinfirebase13-default-rtdb.firebaseio.com/";

        public SignupPage()
        {
            InitializeComponent();

            //StartDate.Time = DateTime.Now.TimeOfDay;
            //EndDate.Time = DateTime.Now.TimeOfDay;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.White;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.White;
        }

        private async void SignupButton_Clicked(object sender, EventArgs e)
        {
            SalonInformationModel salon = new SalonInformationModel();
            salon.SalonName = SalonName.Text;
            salon.Password = Password.Text;
            //salon.salonType = SalonType.Text;
            salon.UserID = UserID.Text;
            salon.Address = Address.Text;
            salon.phoneNumber = PhoneNumber.Text;
            //salon.openingHours = openingHours.Text;
            //salon.dayOff = dayOff.Text;
            //salon.services = services;


            try
            {

                if (string.IsNullOrEmpty(salon.SalonName))
                {
                    await DisplayAlert("Warning", "Please enter your Salon name ", "Cancel");
                    return;
                }

                if (string.IsNullOrEmpty(salon.UserID))
                {
                    await DisplayAlert("Warning", "Please enter your salonId ", "Cancel");
                    return;
                }

                if (salon.Password.Length < 6)
                {
                    await DisplayAlert("Warning", "password should be more 6 digit", "Cancel");
                    return;
                }

                if (string.IsNullOrEmpty(salon.Password))
                {
                    await DisplayAlert("Warning", "Please enter your password ", "Cancel");
                    return;
                }
                if (string.IsNullOrEmpty(salon.Address))
                {
                    await DisplayAlert("Warning", "Please enter  your address ", "Cancel");
                    return;
                }
                /*if (string.IsNullOrEmpty(salon. city))
                {
                    await DisplayAlert("Warning", "Please enter city ", "Cancel");
                    return;
                }*/
                var config = new FirebaseAuthConfig
                {
                    ApiKey = FirebaseApiKey,
                    AuthDomain = "beautybookapp-a44e5.firebaseapp.com",
                    Providers = new FirebaseAuthProvider[] { new EmailProvider() }
                };

                bool isSave = await _userDB.SaveSalonInfo(salon);
                if (isSave)
                {
                    await DisplayAlert("Register user", "Regestiration compleated ", "ok");
                    await Navigation.PushAsync(new AgendaPage());

                }
                else
                {
                    await DisplayAlert("Register user", "Regestiration faild ", "ok");

                }
            }
            catch (Exception exception)
            {
                await DisplayAlert("Errore", exception.Message, "ok");
            }
        }
    } 
}