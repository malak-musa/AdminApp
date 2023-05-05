using BeautyBookAdminApp.Views;
using LiteDB;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeautyBookAdminApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override async void OnStart()
        {
            var oauth_token = await SecureStorage.GetAsync("oauth_token");
            if (!string.IsNullOrEmpty(oauth_token))
            {
                MainPage = new NavigationPage(new AgendaPage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
