﻿using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Logic
{
    public class TableLogic
    {
        private RestaurantDBContext db = new RestaurantDBContext();

        public List<Tables> getTablesReservation(DateTime fromTime, DateTime endTime)
        {

            var query = from r in db.Reservations
                        where r.date_time < fromTime && r.date_time > endTime
                        join o in db.Orders on r.Id equals o.Reservations_id
                        into temp
                        let te = temp.DefaultIfEmpty()
                        from tt in te
                        select new
                        {
                            r.table_number,
                            state = (tt.state == null) ? 0 : tt.state
                        };
            var query2 = from t in db.Tables
                         join q in query on t.Id equals q.table_number into temp
                         let te = temp.DefaultIfEmpty()
                         from tt in te
                         select new
                         {
                             Id = t.Id,
                             x = t.x,
                             y = t.y,
                             size = t.size,
                             state = (tt.state == null) ? 4 : tt.state
                         };
            List<Tables> listt = new List<Tables>();

            foreach (var item in query2.ToList())
            {
                listt.Add(new Tables(item.Id, item.x, item.y, item.size, item.state));
            }

            return listt;
        }
    }
}