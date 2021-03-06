﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
    public class MainModel
    {
        public Reservations Reservations { get; set; }
        public IEnumerable<Orders> Orders { get; set; }
        public IEnumerable<Foods> Foods { get; set; }
        public IEnumerable<Tables> Tables { get; set; }
    }
}