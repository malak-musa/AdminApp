using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyBookCustomerApp.Models
{
    public class SalonInformationModel
    {
        public string userID { set; get; }
        public string password { set; get; }
        public string salonName { set; get; }
        public string salonType { set; get; }
        public string address { set; get; }
        public string city { set; get; }
        //public string services { set; get; }
        public string openingStartHours { set; get; }
        public string openingEndHours { set; get; }

        public string phoneNumber { set; get; }
    }
}
