using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleAPI.Models
{
    public class Hotel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double Latitute { get; set; }
        public double Longitude { get; set; }
    }
}