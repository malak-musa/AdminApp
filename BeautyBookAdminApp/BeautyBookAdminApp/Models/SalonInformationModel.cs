using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyBookAdminApp.Models
{
    public class SalonInformationModel
    {
        public string UserID { set; get; }
        public string Password { set; get; }
        public string SalonName { set; get; }
        public string SalonType { set; get; }
        public string Address { set; get; }
        public string City { set; get; }
        public string Services { set; get; }
        public string OpeningStartHours { set; get; }
        public string OpeningEndHours { set; get; }

        public string phoneNumber { set; get; }
    }
}
