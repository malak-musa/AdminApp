using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BeautyBookAdminApp.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using BeautyBookAdminApp.Models;
using Firebase.Database;

namespace BeautyBookAdminApp.ViewModels
{
    public class AgendaViewModel : ObservableObject
    {
        public Database database;
        FirebaseObject<BookingModel> _selectedItem;
        public FirebaseObject<BookingModel> SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != null)
                    _selectedItem = null;
                
                OnPropertyChanged();
            }
        }
        public List<FirebaseObject<BookingModel>> RequestedList { set; get; }

        public AgendaViewModel()
        {
            database = new Database();
            var t = Task.Run(async() =>
            {
                RequestedList = await database.GetBooking();
            });
            t.Wait();
        }
    }
}
