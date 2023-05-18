using System;
using System.Collections.Generic;
using System.Text;
using static BeautyBookAdminApp.Views.AddSercivesPage;

namespace BeautyBookAdminApp.Models
{
    public class SalonInformationModel
    {
        //public string Address { get; set; }
        //public string DaysOff { get; set; }
        //public string ImagURL { get; set; }
        //public string OpeningHour { get; set; }
        //public string PhoneNumber { get; set; }
        //public string SalonName { get; set; }
        //public string SalonType { get; set; }
        //public string UserId { get; set; }
        //public string City { get; set; }
        //public List<Service> Services { set; get; }
        public string Address { get; set; }
        public string ImagURL { get; set; }
        public string OpeningHour { get; set; }
        public string PhoneNumber { get; set; }
        public string SalonName { get; set; }
        public string SalonType { get; set; }
        public List<Service> ?Services { get; set; }
        public string UserId { get; set; }
    }
}
