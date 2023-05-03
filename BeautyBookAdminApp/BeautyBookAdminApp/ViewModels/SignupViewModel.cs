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
using beautyBookAdmin.Services;

namespace BeautyBookAdminApp.ViewModels
{
    class SignupViewModel
    {
        public string UserID { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string SalonName { set; get; }
        public string SalonType { set; get; }
        public string Address { set; get; }
        public string OpeningStartHours { set; get; }
        public string OpeningEndHours { set; get; }
        public string PhoneNumber { set; get; }
        public string ConfirmPassword { get; set; }
        public ICommand SigUpButton { get; }

        private Database _firebase;

        public SignupViewModel()
        {
            _firebase = new Database();

            SigUpButton = new Command(async () => await AddUser());


        }

        private async Task AddUser()
        {
            AuthModel addUser = new AuthModel();
            {
                addUser.SalonName = SalonName;
                addUser.SalonType = "womane Salon";
                addUser.PhoneNumber = PhoneNumber;
                addUser.Address = Address;
                addUser.OpeingHoures = OpeningStartHours + " " + OpeningEndHours;
                addUser.ImagURL = "";
                addUser.DaysOff = "Monday";
            }
            await _firebase.SingUp(addUser,Email,Password);
        }


    }
}
