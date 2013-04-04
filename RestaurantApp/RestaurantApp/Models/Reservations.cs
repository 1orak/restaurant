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

        public string date { get; set; }

        public string time { get; set; }


        #region konwersja daty i godziny mysql

        public DateTime getTime()
        {
            return Convert.ToDateTime(time);
        }

        public DateTime getDate()
        {
            return Convert.ToDateTime(date);
        }

        public void setTime(DateTime dt)
        {
            time = dt.ToShortTimeString();
        }

        public void setDate(DateTime dt)
        {
            date = dt.ToShortDateString();
        }

        #endregion
    }
}