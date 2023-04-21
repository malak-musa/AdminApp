using beautyBookAdmin.Services;
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
    public partial class LoginPage : ContentPage
    {
        Database _userDB = new Database();
        private const string FirebaseApiKey = "AIzaSyA37bTpBm27kjiHDuf5tigFwCmVsxmEYsY ";
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isLogin = await _userDB.Login(Username.Text, Password.Text);

            if (isLogin)
            {
                await Navigation.PushAsync(new AgendaPage());
            }
            else
            {
                await DisplayAlert("Error", "Incorrect username or password", "OK");
            }
        }

        private async void OnSignupLabelTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());

        }
    }
}