using System;
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
                ViewBag.Message = "Data base connect";
            }
            catch
            {
                ViewBag.Message = "It was error retrieving data from DB";
            }          

            return View();
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
