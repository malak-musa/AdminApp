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

namespace beautyBookAdmin.Services
{
    public class Database
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://beautybookapp-a44e5-default-rtdb.europe-west1.firebasedatabase.app/");

        public async Task<bool> SaveSalonInfo(SalonInformationModel salon)
        {
            var data = await firebaseClient.Child(nameof(SalonProfileViewmodel)).PostAsync(JsonConvert.SerializeObject(salon));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;

            }
            return false;
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
        
        public async Task<bool> Login(string Username, string Password)
        {

            var salonInfo = await firebaseClient.Child(nameof(SalonInformationModel)).OnceAsync<SalonInformationModel>();
            
                foreach (var item in salonInfo)
                {
                    if (item.Object.UserID == Username && item.Object.Password == Password)
                    {
                        return true;
                    }
                }

            return false;
        }


    }
}
