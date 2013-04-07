using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Models
{
    public class Orders
    {
        public int Id { get; set; }

        public int Reservations_id { get; set; }

        public int Foods_id { get; set; }

        public string note { get; set; }

        public int state { get; set; }

        public DateTime date_time { get; set; }

        public DateTime date_time_to_end { get; set; }

        public decimal price { get; set; }

    }
}