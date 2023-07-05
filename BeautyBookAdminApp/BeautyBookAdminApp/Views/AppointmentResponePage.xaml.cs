using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautyBookAdminApp.Services;
using BeautyBookAdminApp.Models;
using Firebase.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeautyBookAdminApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentResponePage : ContentPage
    {
        private readonly Database database;
        FirebaseObject<BookingModel> Deatails { set; get; }

        public AppointmentResponePage(FirebaseObject<BookingModel> deatails)
        {
            InitializeComponent();
        }

        private async void AcceptButton_Clicked(object sender, EventArgs e)
        {
            await database.EditBookingStatus(Deatails.Key, "Accept");
        }

        private async void RejectButton_Clicked(object sender, EventArgs e)
        {
            await database.EditBookingStatus(Deatails.Key, "rejct");
        }
    }
}