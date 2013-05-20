using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        [NotMapped]
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

    }
}