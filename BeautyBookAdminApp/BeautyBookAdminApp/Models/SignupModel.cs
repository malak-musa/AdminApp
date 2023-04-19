using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace BeautyBookAdminApp.Models
{
    public class SignupModel
    {
        public string SalonName { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string SalonAddress { get; set; }
        public string City { get; set; }
        public string SalonType { get; set; }
        //public string DayOff { get; set; }
        //public bool IsChecked { get; set; }
    }
}
