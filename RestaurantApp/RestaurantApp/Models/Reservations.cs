using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
    public class Reservations
    {
        public int Id { get; set; }

        public int table_number { get; set; }

        public DateTime date_time { get; set; }

    }
}