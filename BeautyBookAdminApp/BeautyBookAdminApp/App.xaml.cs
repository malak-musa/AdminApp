using BeautyBookAdminApp.Views;
using LiteDB;
using System;
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

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
