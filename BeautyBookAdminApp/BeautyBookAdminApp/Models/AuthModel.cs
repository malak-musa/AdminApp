using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyBookAdminApp.Models
{
    public class AuthModel
    {
        public string UserId { set; get; }
        public string Password { set; get; }
        public string SalonName { set; get; }
        public string SalonType { set; get; }
        public string City { set; get; }
        public string Address { set; get; }
        public string OpeningHour { set; get; }
        public string Email { set; get; }   
        public string PhoneNumber {set; get; }
        public List<string> Services { set; get; }
    }
}
