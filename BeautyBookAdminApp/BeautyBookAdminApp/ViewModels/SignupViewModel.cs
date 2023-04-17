using BeautyBookAdminApp.Models;
using BeautyBookAdminApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;

namespace BeautyBookAdminApp.ViewModels
{
    class SignupViewModel
    {
        public IList<SignupModel> SalonCollection { get; set; }
        public IList<SignupModel> Cities { get; set; }

        public SignupViewModel()
        {
            // Salon Types
            SalonCollection = new ObservableCollection<SignupModel>();
            SalonCollection.Add(new SignupModel { SalonType = "Men's Salon" });
            SalonCollection.Add(new SignupModel { SalonType = "Women's Salon" });
            SalonCollection.Add(new SignupModel { SalonType = "Unisex Salon" });

            // Cities
            Cities = new ObservableCollection<SignupModel>();
            Cities.Add(new SignupModel { City = "Jerusalem" });
            Cities.Add(new SignupModel { City = "Bethlehem" });
            Cities.Add(new SignupModel { City = "Hebron" });
            Cities.Add(new SignupModel { City = "Sabastia" });
            Cities.Add(new SignupModel { City = "Jericho" });
            Cities.Add(new SignupModel { City = "Ramallah" });
            Cities.Add(new SignupModel { City = "Nablus" });
            Cities.Add(new SignupModel { City = "Jenin" });
            Cities.Add(new SignupModel { City = "Tulkarem" });
        }
    }
}
