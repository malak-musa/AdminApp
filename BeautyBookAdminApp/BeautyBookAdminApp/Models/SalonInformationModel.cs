using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyBookAdminApp.Models
{
    public class SalonInformationModel
    {
  
        public string ImagURL { get; set; }
        public string Address { get; set; }
        public string SalonName { get; set; }
        public string DaysOff { get; set; }
        public string OpeingHoures { get; set; }
        public string SalonType { get; set; }
        public string PhoneNumber { get; set; }

        public string userId { get; set; }
    }
}