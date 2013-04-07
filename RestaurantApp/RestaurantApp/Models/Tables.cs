using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Models
{
    public class Tables
    {
        public int Id { get; set; }

        public int x { get; set; }

        public int y { get; set; }

        public int size { get; set; }

        [NotMapped]
        public int state { get; set; }

        public Tables(int id, int x, int y, int size, int state)
        {
            this.Id = id;
            this.x = x;
            this.y = y;
            this.size = size;
            this.state = state;
        }
    }
}