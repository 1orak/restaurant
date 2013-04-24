using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using RestaurantApp.Models;


namespace RestaurantApp.Controllers
{
    public class ViewFoodsController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();
        //
        // GET: /ViewFoods/

        public ActionResult Index(int reservation_id = 0)
        {
            ViewBag.Reservation_id = reservation_id;

            return View(db.Foods.ToList().OrderBy(x => x.category));
        }

        public ActionResult Add_order(int reservation_id, int food_id)
        {
            Orders new_order = new Orders();
            Foods food = db.Foods.Find(food_id);
            Reservations reservation = db.Reservations.Find(reservation_id);

            //wypelnienie row
            new_order.Foods_id = food_id;
            new_order.Reservations_id = reservation_id;
            new_order.state = 0;
            new_order.price = food.price;
            new_order.date_time = Convert.ToDateTime(reservation.date_time);

            //dodanie nowej pozycji
            try
            {
                db.Orders.Add(new_order);
                db.SaveChanges();
                return RedirectToAction("Index", new { reservation_id=reservation_id });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ViewFoods/Details/5

        public ActionResult Details(int id)
        {
            
            Foods foods = db.Foods.Find(id);
            return View(foods);
        }

        public ActionResult SearchIndex(string searchString, int foodCategory = 0, int foodTime = 0, decimal foodPrice = -1)
        {
            //**************************************
            // kategoria, czas nie mogą być NULL ani 0, cena nie może być ujemna lub Null
            //**************************************
            //tworzenie listy kategorii
            var CategoryLst = new List<int>();

            var CategoryQry = from d in db.Foods
                           orderby d.category
                           select d.category;
            CategoryLst.AddRange(CategoryQry.Distinct());
            ViewBag.foodCategory = new SelectList(CategoryLst);
            //***************************************
            //tworzenie listy czasow
            var TimeLst = new List<int>();

            var TimeQry = from e in db.Foods
                              orderby e.time_to_prepare
                              select e.time_to_prepare;
            TimeLst.AddRange(TimeQry.Distinct());
            ViewBag.foodTime = new SelectList(TimeLst);
            //**************************************
            //tworzenie listy cen
            var PriceLst = new List<decimal>();

            var PriceQry = from e in db.Foods
                              orderby e.price
                              select e.price;
            PriceLst.AddRange(PriceQry.Distinct());
            ViewBag.foodPrice = new SelectList(PriceLst);
            //**************************************
            var foods = from m in db.Foods
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                foods = foods.Where(s => s.name.Contains(searchString)); //wszystkie rekordy zawierajace string
            }

           
            if(foodCategory != 0) //if nie wybrana kategoria -> pomin
            {
                foods = foods.Where(x => x.category == foodCategory);  //rekordy okreslonej kategorii
            }
            if (foodTime != 0) // if nie wybrany czas -> pomin
            {
                foods = foods.Where(x => x.time_to_prepare == foodTime); //rekordy okreslonego czasu
            }
            if( foodPrice >= 0) //if nie wybrana cena -> pomic
            {
                foods = foods.Where(x => x.price == foodPrice); // rekordy okreslonej ceny
            }
            
                return View(foods.OrderBy(x => x.name)); //sortuj wedlug nazwy, zwroc widok
            

        }
        

        //
        // GET: /ViewFoods/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ViewFoods/Create

        [HttpPost]
        public ActionResult Create(Foods foods)
        {
           
                if (ModelState.IsValid)
                {
                    db.Foods.Add(foods);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(foods);
            
        }

        //
        // GET: /ViewFoods/Edit/5

        public ActionResult Edit(int id)
        {
            Foods foods = db.Foods.Find(id);
            return View(foods);
        }

        //
        // POST: /ViewFoods/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Foods foods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foods).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foods);
        }

        //
        // GET: /ViewFoods/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ViewFoods/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Foods food=db.Foods.Find(id);
                db.Foods.Remove(food);
                db.SaveChanges();
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
