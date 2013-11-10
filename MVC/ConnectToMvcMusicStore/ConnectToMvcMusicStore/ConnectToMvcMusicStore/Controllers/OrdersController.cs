using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConnectToMvcMusicStore.Models;

namespace ConnectToMvcMusicStore.Controllers
{
    public class OrdersController : Controller
    {
        private OrdersDBContext db = new OrdersDBContext();

        //
        // GET: /Orders/

        public ActionResult Index(string sortOrder, string searchString)
        {
            //create sorting parameters for orderdate and total colum

            ViewBag.OrderDateSortParm = String.IsNullOrEmpty(sortOrder) ? "OrderDate_desc" : "";
            ViewBag.TotalSortParm = sortOrder == "Total" ? "Total_desc" : "Total";
            var Orders = from s in db.OrdersDbSet
                           select s;

            //setup linq query to search data 
            if (!String.IsNullOrEmpty(searchString))
            {
                Orders = Orders.Where(s => s.Username.ToUpper().Contains(searchString.ToUpper())
                                       || s.FirstName.ToUpper().Contains(searchString.ToUpper())
                                        || s.LastName.ToUpper().Contains(searchString.ToUpper()
                                       ));

            }


            // useing switch statement to order the data 

            switch (sortOrder)
            {
                case "OrderDate_desc":
                    Orders = Orders.OrderByDescending(s => s.OrderDate);
                    break;
                case "Total":
                    Orders = Orders.OrderBy(s => s.Total);
                    break;
                case "Total_desc":
                    Orders = Orders.OrderByDescending(s => s.Total);
                    break;
                default:
                    Orders = Orders.OrderBy(s => s.OrderDate);
                    break;
            }
            return View(Orders.ToList());
        }

        //
        // GET: /Orders/Details/5

        public ActionResult Details(int id = 0)
        {
            Orders orders = db.OrdersDbSet.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        //
        // GET: /Orders/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Orders/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.OrdersDbSet.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orders);
        }

        //
        // GET: /Orders/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Orders orders = db.OrdersDbSet.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        //
        // POST: /Orders/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orders);
        }

        //
        // GET: /Orders/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Orders orders = db.OrdersDbSet.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        //
        // POST: /Orders/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.OrdersDbSet.Find(id);
            db.OrdersDbSet.Remove(orders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}