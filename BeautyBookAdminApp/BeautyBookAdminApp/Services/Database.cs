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
using LiteDB;
using Xamarin.Forms;
using static BeautyBookAdminApp.Views.AddSercivesPage;

namespace BeautyBookAdminApp.Services
{
    public class Database
    {
        readonly FirebaseClient firebaseClient = new FirebaseClient("https://beautybookapp-a44e5-default-rtdb.europe-west1.firebasedatabase.app/");
        private const string FirebaseApiKey = "AIzaSyA37bTpBm27kjiHDuf5tigFwCmVsxmEYsY";
        readonly FirebaseAuthClient client = new FirebaseAuthClient(config);
        
        static readonly FirebaseAuthConfig config = new FirebaseAuthConfig
        {
            ApiKey = FirebaseApiKey,
            AuthDomain = "beautybookapp-a44e5.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider()
            }
        };

        public async Task SingUp(AuthModel authModel, string email, string password)
        {
            try
            {
                var userCredential = await client.CreateUserWithEmailAndPasswordAsync(email, password);
                authModel.UserId = userCredential.User.Uid;

                var salonObj = await firebaseClient.Child("SalonProfile").PostAsync(authModel);

                await SecureStorage.SetAsync("salonId", salonObj.Key);

                await SecureStorage.SetAsync("oauth_token", userCredential.User.Uid);

                if (userCredential.User.Uid != null)
                {
                    App.Current.MainPage = new NavigationPage(new AgendaPage());
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
                var userCredential = await client.SignInWithEmailAndPasswordAsync(email, password);
                string token = userCredential.User.Uid;
                string salonId = await GetSalonId(token);
                await SecureStorage.SetAsync("oauth_token", token);
                await SecureStorage.SetAsync("salonId", salonId);
                if (token != null)
                {
                    App.Current.MainPage = new NavigationPage(new AgendaPage());
                }
            }
            catch (FirebaseAuthException ex)
            {
                if (ex.Reason == AuthErrorReason.UnknownEmailAddress)
                {
                    await App.Current.MainPage.DisplayAlert("Authentication Error", ex.Reason.ToString(), "OK");
                }
                else if (ex.Reason == AuthErrorReason.EmailExists)
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

        public async Task<IReadOnlyCollection<FirebaseObject<BookingModel>>> GetBooking()
        {
            var requestedList = await firebaseClient.Child("BookingModel").OnceAsync<BookingModel>();
            
            return requestedList;
        }

        public async Task<bool> EditBookingStatus(string objectId, string newStatus)
        {
            try
            {
                await firebaseClient.Child("BookingModel").Child(objectId).Child("Status").PutAsync<string>(newStatus);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ObservableCollection<SalonInformationModel> GetSalonProfile()
        {
            var salon = firebaseClient.Child("SalonProfile").AsObservable<SalonInformationModel>().AsObservableCollection();
            
            return salon;
        }

        public async Task<string> GetSalonId(string userId)
        {
            var salonInofo = await firebaseClient.Child("SalonProfile").OnceAsync<SalonInformationModel>();
            var salonId = salonInofo.Where(el => el.Object.UserId == userId).FirstOrDefault().Key;

            return salonId;
        }

        public async Task<IEnumerable<Service>> GetSalonServices(string salonId)
        {
            var servicesObj = await firebaseClient.Child("SalonProfile").Child(salonId).Child("Services").OnceAsListAsync<Service>();
            
            return servicesObj.Select(el => el.Object);
        }
        
        public async Task<bool> AddSalonServices(string userId, IList<Service> serviceNames)
        {
            try
            {
                var salonInofo = await firebaseClient.Child("SalonProfile").OnceAsync<SalonInformationModel>();
                string salonId = salonInofo.Where(el => el.Object.UserId == userId).FirstOrDefault()?.Key;
                
                if (string.IsNullOrEmpty(salonId))
                {
                    return false;
                }

                await firebaseClient.Child("SalonProfile").Child(salonId).Child("Services").PutAsync<IList<Service>>(serviceNames);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task UpdateProfile(SalonInformationModel control)
        {
            string _accessToken = await SecureStorage.GetAsync("oauth_token");
            var toUpdateInfo = (await firebaseClient.Child("SalonProfile").OnceAsync<SalonInformationModel>())
                   .FirstOrDefault(item => item.Object.UserId == _accessToken);
            try
            {
                await firebaseClient
                     .Child("SalonProfile")
                     .Child(toUpdateInfo.Key)
                     .PutAsync(control);
            }
            catch (Exception ex)
            {
                await Xamarin.Forms.Shell.Current.DisplayAlert("Failed", ex.Message, "ok");
            }
        }
    }
}
