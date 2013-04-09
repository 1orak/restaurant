using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantApp.Models;

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
            Reservations reservations = db.Reservations.Find(id);
            return View(reservations);
        }

        //
        // GET: /Reservations/Create

        public ActionResult Create()
        {
            return View();
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
            return View();
        }

        //
        // POST: /Reservations/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Reservations reservation)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
