using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeautyBookAdminApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();

            StartDate.Time = DateTime.Now.TimeOfDay;
            EndDate.Time = DateTime.Now.TimeOfDay;
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
            await Navigation.PushAsync(new AgendaPage());
        }

        private void SignupButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}