using BeautyBookAdminApp.Services;
using BeautyBookAdminApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BeautyBookAdminApp.ViewModels
{
    public class LoginViewModel
    {
        public string Email { set; get; }
        public string Password { set; get; }
        public ICommand SigInButton { get; }
        private Database _firebase;

        public LoginViewModel() {
            _firebase = new Database();
            SigInButton = new Command(async () => await SignIn());
        }

        private async Task SignIn()
        { 
            await _firebase.SingIn(Email, Password);
        }
    }
}
