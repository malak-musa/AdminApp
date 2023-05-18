using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautyBookAdminApp.Services;
using BeautyBookAdminApp.Models;
using BeautyBookAdminApp.ViewModels;
using Firebase.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace BeautyBookAdminApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendaPage : ContentPage
    {
        public AgendaPage()
        {
            BindingContext = new AgendaViewModel();
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new AppointmentResponePage());
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SalonProfileTabBarPage());
        }

        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var collectionView = sender as CollectionView;
            var selectedItem = e.CurrentSelection.FirstOrDefault();

            if (selectedItem != null)
            {
                await Navigation.PushAsync(new AppointmentResponePage((FirebaseObject<BookingModel>)selectedItem));
            }
        }
        private async void Logout_clicked(object sender, EventArgs e)
        {
            // Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            await Application.Current.MainPage.Navigation.PopToRootAsync();
            Application.Current.MainPage = new NavigationPage(new LoginPage());
            SecureStorage.RemoveAll();
        }
    }
}