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
    public class Default1Controller : Controller
    {
        private MvcMusicStoreDBContext db = new MvcMusicStoreDBContext();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View(db.ArtistsDbSet.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            Artists artists = db.ArtistsDbSet.Find(id);
            if (artists == null)
            {
                return HttpNotFound();
            }
            return View(artists);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Artists artists)
        {
            if (ModelState.IsValid)
            {
                db.ArtistsDbSet.Add(artists);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artists);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Artists artists = db.ArtistsDbSet.Find(id);
            if (artists == null)
            {
                return HttpNotFound();
            }
            return View(artists);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Artists artists)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artists).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artists);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Artists artists = db.ArtistsDbSet.Find(id);
            if (artists == null)
            {
                return HttpNotFound();
            }
            return View(artists);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artists artists = db.ArtistsDbSet.Find(id);
            db.ArtistsDbSet.Remove(artists);
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