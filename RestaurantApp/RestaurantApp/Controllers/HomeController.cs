﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers
{
    public class HomeController : Controller
    {
        //ToDo: do usuniecia, testowe
        private RestaurantDBContext db = new RestaurantDBContext();

        public ActionResult Index()
        {
            //ToDo: do usuniecia, testowe
            try
            {
                var foods = db.Foods.Find(1);
                //ViewBag.Message = "From database: " + foods.name;
                ViewBag.Message = "Database connected";
            }
            catch
            {
                ViewBag.Message = "It was error retrieving data from DB";
            }          

            return View(getTablesReservation(DateTime.Now,DateTime.Now.AddHours(-2)));
        }

        private List<Tables> getTablesReservation(DateTime fromTime, DateTime endTime)
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

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
