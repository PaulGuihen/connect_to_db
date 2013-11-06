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

        public ActionResult Index()
        {
            return View(db.OrdersDbSet.ToList());
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