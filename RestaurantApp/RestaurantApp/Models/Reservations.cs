using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
    public class Reservations
    {
        public int Id { get; set; }

        public int table_number { get; set; }
        //konwersja datatime C# na datatime mysql

        //public DateTime date { get; set; }

        //public int time { get; set; }
    }
}