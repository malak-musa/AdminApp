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
        public string Email { set; get; }
        public string Password { set; get; }
        public string SalonName { set; get; }
        public string SalonType { set; get; }
        public string City { set; get; }
        public string Address { set; get; }
        public string OpeningStartHour { set; get; }
        public string OpeningEndHour { set; get; }
        public string PhoneNumber { set; get; }
        public ICommand SigUpButton { get; }
        private readonly Database _firebase;
        public IList<SalonInformationModel> SalonCollection { get; set; }

        public SignupViewModel()
        {
            _firebase = new Database();

            SigUpButton = new Command(async () => await AddUser());

            SalonCollection = new ObservableCollection<SalonInformationModel>
            {
                new SalonInformationModel { SalonType = "Men's Salon" },
                new SalonInformationModel { SalonType = "Women's Salon" },
                new SalonInformationModel { SalonType = "Unisex Salon" }
            };
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
                addUser.Services = null;
            }
            await _firebase.SingUp(addUser,Email,Password);
        }
    }
}
