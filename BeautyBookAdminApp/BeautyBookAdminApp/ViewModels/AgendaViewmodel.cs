using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BeautyBookAdminApp.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using BeautyBookAdminApp.Models;
using Firebase.Database;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

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
                    _selectedItem = value;

                OnPropertyChanged();
            }
        }
        DateTime _selectedDate;
        private List<FirebaseObject<BookingModel>> requestedList;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {

                _selectedDate = value;


                OnPropertyChanged();
            }
        }

        public List<FirebaseObject<BookingModel>> RequestedList
        {
            get => requestedList;
            set
            {
                requestedList = value;
                OnPropertyChanged();
            }
        }
        public ICommand ChangeDateCommand { set; get; }

        public AgendaViewModel()
        {
            ChangeDateCommand = new Command(ChangeDate);
            RequestedList = new List<FirebaseObject<BookingModel>>();
            database = new Database();

        }
        async void ChangeDate()
        {
            string Date = "Date: ";

            string dateString = SelectedDate.ToString("MM/dd/yyyy");

            var EditedDate = Date + dateString;

            var booking = await database.GetBooking();

            var filtered = booking.Where(el => el.Object.Date == EditedDate).ToList();

            RequestedList = filtered;

        }
    }
}