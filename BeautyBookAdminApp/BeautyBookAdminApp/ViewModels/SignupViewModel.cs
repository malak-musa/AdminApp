using BeautyBookAdminApp.Views;
using BeautyBookAdminApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using Firebase.Auth;
using System.Windows.Input;
using Xamarin.Essentials;
using static Xamarin.Essentials.Permissions;
using BeautyBookAdminApp.Services;

namespace BeautyBookAdminApp.ViewModels
{
    class SignupViewModel
    {
        public string UserID { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string SalonName { set; get; }
         public string SalonType { set; get; }
        public string City { set; get; }
        public string Address { set; get; }
        public string OpeningStartHour { set; get; }
        public string OpeningEndHour { set; get; }
        public string PhoneNumber { set; get; }
        public string ConfirmPassword { get; set; }
        public ICommand SigUpButton { get; }
        private Database _firebase;
        public IList<SalonInformationModel> SalonCollection { get; set; }
        public IList<SalonInformationModel> Cities { get; set; }

        public string salonType { set; get; }

        public SignupViewModel()
        {
            _firebase = new Database();

            SigUpButton = new Command(async () => await AddUser());

            // Salon Types
            SalonCollection = new ObservableCollection<SalonInformationModel>();
            SalonCollection.Add(new SalonInformationModel { SalonType = "Men's Salon" });
            SalonCollection.Add(new SalonInformationModel { SalonType = "Women's Salon" });
            SalonCollection.Add(new SalonInformationModel { SalonType = "Unisex Salon" });

            // Cities
            Cities = new ObservableCollection<SalonInformationModel>();
            Cities.Add(new SalonInformationModel { City = "Jerusalem" });
            Cities.Add(new SalonInformationModel { City = "Bethlehem" });
            Cities.Add(new SalonInformationModel { City = "Hebron" });
            Cities.Add(new SalonInformationModel { City = "Sabastia" });
            Cities.Add(new SalonInformationModel { City = "Jericho" });
            Cities.Add(new SalonInformationModel { City = "Ramallah" });
            Cities.Add(new SalonInformationModel { City = "Nablus" });
            Cities.Add(new SalonInformationModel { City = "Jenin" });
            Cities.Add(new SalonInformationModel { City = "Tulkarem" });
        }

        private async Task AddUser()
        {
           
            AuthModel addUser = new AuthModel();
            {
                addUser.SalonName = SalonName;
                addUser.SalonType = SalonType;
                addUser.PhoneNumber = PhoneNumber;
                addUser.City = City;
                addUser.Address = Address;
                addUser.OpeningHour = OpeningStartHour + "--" + OpeningEndHour;
                addUser.ImagURL = "";
                addUser.Services = null;
                //addUser.DaysOff = "Monday";
            }
           await _firebase.SingUp(addUser,Email,Password);
        }
    }
}
