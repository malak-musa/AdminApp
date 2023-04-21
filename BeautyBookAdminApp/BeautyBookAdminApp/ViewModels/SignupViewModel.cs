using BeautyBookAdminApp.Views;
using BeautyBookCustomerApp.Models;
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
        public IList<SalonInformationModel> SalonCollection { get; set; }
        public IList<SalonInformationModel> Cities { get; set; }

        public SignupViewModel()
        {
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
    }
}
