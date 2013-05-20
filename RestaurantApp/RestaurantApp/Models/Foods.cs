using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Models
{
    public class Foods
    {
        public int Id { get; set; }

        public string name { get; set; }

        [ForeignKey("Category")]
        [Column("category")]
        public int categoryId { get; set; }

        public virtual Category Category { get; set; }

        public string description { get; set; }

        [DataType(DataType.Currency)]
        public decimal price { get; set; }

        public int time_to_prepare { get; set; }

    }
}