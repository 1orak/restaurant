using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Models
{
    public class Foods
    {
        public int Id { get; set; }

        public string name { get; set; }

        public int category { get; set; }

        public string description { get; set; }

        [DataType(DataType.Currency)]
        public decimal price { get; set; }

        public int time_to_prepare { get; set; }

    }

    public enum Categories
    {
        drinks = 1,
        mains = 2,
        starters = 3,
        beers = 4,
        breakfast = 5,
        soop = 6
    }
}