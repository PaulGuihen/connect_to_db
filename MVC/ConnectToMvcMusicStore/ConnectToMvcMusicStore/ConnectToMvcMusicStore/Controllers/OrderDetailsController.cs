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
    public class OrderDetailsController : Controller
    {
        private OrderDetailsDBContext db = new OrderDetailsDBContext();

        //
        // GET: /OrderDetails/

        public ActionResult Index()
        {
            return View(db.OrderDetails.ToList());
        }

        //
        // GET: /OrderDetails/Details/5

        public ActionResult Details(int id = 0)
        {
            OrderDetails orderdetails = db.OrderDetails.Find(id);
            if (orderdetails == null)
            {
                return HttpNotFound();
            }
            return View(orderdetails);
        }

        //
        // GET: /OrderDetails/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OrderDetails/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetails orderdetails)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetails.Add(orderdetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderdetails);
        }

        //
        // GET: /OrderDetails/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OrderDetails orderdetails = db.OrderDetails.Find(id);
            if (orderdetails == null)
            {
                return HttpNotFound();
            }
            return View(orderdetails);
        }

        //
        // POST: /OrderDetails/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderDetails orderdetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderdetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderdetails);
        }

        //
        // GET: /OrderDetails/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OrderDetails orderdetails = db.OrderDetails.Find(id);
            if (orderdetails == null)
            {
                return HttpNotFound();
            }
            return View(orderdetails);
        }

        //
        // POST: /OrderDetails/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetails orderdetails = db.OrderDetails.Find(id);
            db.OrderDetails.Remove(orderdetails);
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