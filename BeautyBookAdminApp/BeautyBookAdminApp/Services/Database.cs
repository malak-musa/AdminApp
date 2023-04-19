using BeautyBookAdminApp.ViewModels;
using BeautyBookCustomerApp.Models;
using Firebase.Database;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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

       
        public async Task<bool> Login(string Username, string Password)
        {

            var salonInfo = await firebaseClient.Child(nameof(SalonInformationModel)).OnceAsync<SalonInformationModel>();
            
                foreach (var item in salonInfo)
                {
                    if (item.Object.userID == Username && item.Object.password == Password)
                    {
                        return true;
                    }
                }

            return false;
        }


    }
}
