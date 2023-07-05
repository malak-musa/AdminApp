using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyBookAdminApp.Models
{
    public class BookingModel
    {
        public string CustomerName { get; set; }
        public int CustomerPhone { get; set; }
        public string Date { get; set; }
        public string SalonName { get; set; }
        public string Services { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }
    }
}
