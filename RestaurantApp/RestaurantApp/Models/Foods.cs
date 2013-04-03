using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RestaurantApp.Models
{
    public class Foods
    {
        public int Id { get; set; }

        public string name { get; set; }

        public int category { get; set; }

        public string description { get; set; }

        public float price { get; set; }

        public int time_to_prepare { get; set; }

    }
}