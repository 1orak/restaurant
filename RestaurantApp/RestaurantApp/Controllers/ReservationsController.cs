﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantApp.Models;
using RestaurantApp.Logic;

namespace RestaurantApp.Controllers
{
    public class ReservationsController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();
        //
        // GET: /Reservations/

        public ActionResult Index()
        {
            
            return View(db.Reservations.ToList());
        }

        //
        // GET: /Reservations/Details/5

        public ActionResult Details(int id)
        {
            ViewBag.Reservation_id = id;
            Reservations reservation = db.Reservations.Find(id);
            var foods = db.Foods.ToList();
            ViewBag.Date = reservation.date_time.Date.ToShortDateString();
            ViewBag.Time = reservation.date_time.TimeOfDay;
            ViewBag.Table = reservation.table_number;

            var orders = from m in db.Orders select m;
            orders = orders.Where(x => x.Reservations_id == id);
            if (orders.Count() != 0)
            {
                ViewBag.Price = orders.Sum(x => x.price);
                ViewBag.TimeToEndSum = orders.Max(x => x.date_time_to_end) - reservation.date_time;
                //ToDo ViewBag.Time/Date
            }
            else
            {
                ViewBag.Price = 0;
                ViewBag.TimeToEndSum = 0;
            }
            
            var mainModel = new MainModel();
            mainModel.Reservations = reservation;
            mainModel.Orders = orders;
            mainModel.Foods = foods;
            return View(mainModel);
        }

        //
        // GET: /Reservations/Create

        public ActionResult Create()
        {
            var categoryList = db.Tables.Select(x => x.Id).Distinct();
            ViewBag.table_number = new SelectList(categoryList);

            var tableLogic = new TableLogic();
            var tableList = tableLogic.getTablesReservation(DateTime.Now, DateTime.Now.AddHours(-2));

            ViewData["tableList"] = tableList;

            return View();
        }

        public PartialViewResult RefreshTableViews(DateTime datetime)
        {
            var tableLogic = new TableLogic();
            var tableList = tableLogic.getTablesReservation(datetime, datetime.AddHours(-2));

            return PartialView("_ShowTables", tableList);
        }

        //
        // POST: /Reservations/Create

        [HttpPost]
        public ActionResult Create(Reservations reservation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(reservation);
            }
            catch
            {
                return View(reservation);
            }
        }

        //
        // GET: /Reservations/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }


        //
        // POST: /Reservations/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Reservations reservation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(reservation);
            }
            catch
            {
                return View(reservation);
            }
        }

        //
        // GET: /Reservations/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                
                    Reservations reservation1 = new Reservations();
                    reservation1 = db.Reservations.Find(id);
                    db.Reservations.Remove(reservation1);
                    db.SaveChanges();
                    //ToDo 
                    // Jeżeli usuwam rezerwacje to należy usunąć też wszystkie rekordy z orders z nim zwiazane
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Reservations/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Reservations reservation)
        {
            try
            {
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult DeleteDetail(int id, int reservation_id)
        {
            try
            {

                Orders order = new Orders();
                order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = reservation_id });
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult DeleteDetail(int id, int reservation_id, Reservations reservation)
        {
            try
            {

                return RedirectToAction("Details", new { id = reservation_id });
            }
            catch
            {
                return View();
            }
        }




    }
}
