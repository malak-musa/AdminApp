﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyBookAdminApp.Models
{
    public class AuthModel
    {
        public string userId { set; get; }
        public string Password { set; get; }
        public string SalonName { set; get; }
        public string SalonType { set; get; }
        public string Address { set; get; }
        public string OpeingHoures { set; get; }
        public string Email { set; get; }   
        public string PhoneNumber {set; get; }
        public string ImagURL { set; get; }
        public string DaysOff { set; get; }

    }
}
