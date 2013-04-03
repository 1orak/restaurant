using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RestaurantApp.Models
{
    public class RestaurantDBContext : DbContext
    {
        public DbSet<Test> Test { get; set; }
        public DbSet<Foods> Foods { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
    }
}