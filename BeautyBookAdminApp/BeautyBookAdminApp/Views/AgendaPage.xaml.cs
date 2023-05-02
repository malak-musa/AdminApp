using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using beautyBookAdmin.Services;
using BeautyBookAdminApp.Models;
using BeautyBookAdminApp.ViewModels;
using Firebase.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeautyBookAdminApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendaPage : ContentPage
    {

        public AgendaPage()
        {

                BindingContext = new AgendaViewmodel();
                InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            //await Navigation.PushAsync(new AppointmentResponePage());
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileServices());
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
    }
}