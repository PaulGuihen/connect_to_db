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
    public class AlbumsController : Controller
    {
        private AlbumsDBContext db = new AlbumsDBContext();

        //
        // GET: /Albums/

        public ActionResult Index()
        {
            return View(db.AlbumsDbSet.ToList());
        }

        //
        // GET: /Albums/Details/5

        public ActionResult Details(int id = 0)
        {
            Albums albums = db.AlbumsDbSet.Find(id);
            if (albums == null)
            {
                return HttpNotFound();
            }
            return View(albums);
        }

        //
        // GET: /Albums/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Albums/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Albums albums)
        {
            if (ModelState.IsValid)
            {
                db.AlbumsDbSet.Add(albums);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(albums);
        }

        //
        // GET: /Albums/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Albums albums = db.AlbumsDbSet.Find(id);
            if (albums == null)
            {
                return HttpNotFound();
            }
            return View(albums);
        }

        //
        // POST: /Albums/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Albums albums)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albums).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(albums);
        }

        //
        // GET: /Albums/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Albums albums = db.AlbumsDbSet.Find(id);
            if (albums == null)
            {
                return HttpNotFound();
            }
            return View(albums);
        }

        //
        // POST: /Albums/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Albums albums = db.AlbumsDbSet.Find(id);
            db.AlbumsDbSet.Remove(albums);
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