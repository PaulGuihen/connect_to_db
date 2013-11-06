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
    public class CartsController : Controller
    {
        private CartsDBContext db = new CartsDBContext();

        //
        // GET: /Carts/

        public ActionResult Index()
        {
            return View(db.CartsDbSet.ToList());
        }

        //
        // GET: /Carts/Details/5

        public ActionResult Details(int id = 0)
        {
            Carts carts = db.CartsDbSet.Find(id);
            if (carts == null)
            {
                return HttpNotFound();
            }
            return View(carts);
        }

        //
        // GET: /Carts/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Carts/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Carts carts)
        {
            if (ModelState.IsValid)
            {
                db.CartsDbSet.Add(carts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carts);
        }

        //
        // GET: /Carts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Carts carts = db.CartsDbSet.Find(id);
            if (carts == null)
            {
                return HttpNotFound();
            }
            return View(carts);
        }

        //
        // POST: /Carts/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Carts carts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carts);
        }

        //
        // GET: /Carts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Carts carts = db.CartsDbSet.Find(id);
            if (carts == null)
            {
                return HttpNotFound();
            }
            return View(carts);
        }

        //
        // POST: /Carts/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carts carts = db.CartsDbSet.Find(id);
            db.CartsDbSet.Remove(carts);
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