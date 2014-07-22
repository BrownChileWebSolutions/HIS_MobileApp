using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace HIS_MobileApp.Models
{
    public class Hotel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string group_email { get; set; }

    }
}