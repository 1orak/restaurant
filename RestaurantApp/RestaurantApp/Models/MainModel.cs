using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
    public class MainModel
    {
        public Reservations Reservations { get; set; }
        public IEnumerable<Orders> Orders { get; set; }
        public Foods Foods { get; set; }
    }
}