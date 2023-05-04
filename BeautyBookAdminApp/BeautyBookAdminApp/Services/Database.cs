using BeautyBookAdminApp.ViewModels;
using BeautyBookAdminApp.Models;
using Firebase.Database;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using Firebase.Auth;
using Firebase.Auth.Providers;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using BeautyBookAdminApp;
using BeautyBookAdminApp.Views;

namespace beautyBookAdmin.Services
{
    public class Database
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://beautybookapp-a44e5-default-rtdb.europe-west1.firebasedatabase.app/");
        private const string FirebaseApiKey = "AIzaSyA37bTpBm27kjiHDuf5tigFwCmVsxmEYsY";
        public async Task<bool> SaveSalonInfo(SalonInformationModel salon)
        {
            var data = await firebaseClient.Child(nameof(SalonProfileViewmodel)).PostAsync(JsonConvert.SerializeObject(salon));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;

            }
            return false;
        }

        public async Task SingUp(AuthModel authModel,string email,string password)
        {

            try
            {
               
                Debug.WriteLine("email"+email);
                var config = new FirebaseAuthConfig
                {
                    ApiKey = FirebaseApiKey,
                    AuthDomain = "beautybookapp-a44e5.firebaseapp.com",
                    Providers = new FirebaseAuthProvider[]
                       {
                        new EmailProvider()
                       }
                };

                var client = new FirebaseAuthClient(config);

                var userCredential = await client.CreateUserWithEmailAndPasswordAsync(email,password);
                authModel.userId = userCredential.User.Uid;
              
                await firebaseClient.Child("SalonProfile").PostAsync(authModel);
                if(userCredential.User.Uid!=null)
                {
                    App.Current.MainPage = new LoginPage();
                }

            }
            catch (FirebaseAuthException ex)
            {
                if (ex.Reason == AuthErrorReason.InvalidEmailAddress)
                {
                    await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Reason.ToString(), "OK");

                }
                else if (ex.Reason == AuthErrorReason.EmailExists)
                {
                    await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Reason.ToString(), "OK");

                }
                else if (ex.Reason == AuthErrorReason.WeakPassword)
                {
                    await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Reason.ToString(), "OK");

                }

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Message.ToString(), "OK");

            }


        }
        public async Task SingIn(string email, string password)
        {

            try
            {

           
                var config = new FirebaseAuthConfig
                {
                    ApiKey = FirebaseApiKey,
                    AuthDomain = "beautybookapp-a44e5.firebaseapp.com",
                    Providers = new FirebaseAuthProvider[]
                       {
                        new EmailProvider()
                       }
                };

                var client = new FirebaseAuthClient(config);

                var userCredential = await client.SignInWithEmailAndPasswordAsync(email, password);
                string token =  userCredential.User.Uid;
      
                await SecureStorage.SetAsync("oauth_token", token);
                if(token !=null)
                {

                     App.Current.MainPage = new AgendaPage();
                }


            }
            catch (FirebaseAuthException ex)
            {
                if (ex.Reason == AuthErrorReason.UnknownEmailAddress)
                {
                    await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Reason.ToString(), "OK");

                }
                else
            if (ex.Reason == AuthErrorReason.EmailExists)
                {
                    await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Reason.ToString(), "OK");

                }
                else if (ex.Reason == AuthErrorReason.WrongPassword)
                {
                    await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Reason.ToString(), "OK");

                }

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Message.ToString(), "OK");

            }


        }

        public async Task<List<FirebaseObject<BookingModel>>> GetBooking()
        {
            var requestedList= await firebaseClient.Child("BookingModel").OnceAsync<BookingModel>();

            return requestedList.ToList();

        }
        public async Task<bool> EditBookingStatus(string objectId,string newStatus)
        {
            try
            {
                await firebaseClient.Child("BookingModel").Child(objectId).Child("Status").PutAsync<string>(newStatus);

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }
        public ObservableCollection<SalonInformationModel> getSalonProfile()
        {
            var salon = firebaseClient.Child("SalonProfile").AsObservable<SalonInformationModel>().AsObservableCollection();


            return salon;
        }





    }
}
