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
    public class GenreController : Controller
    {
        private GenreDBContext db = new GenreDBContext();

        //
        // GET: /Genre/

        public ActionResult Index()
        {
            return View(db.GenresDbSet.ToList());
        }

        //
        // GET: /Genre/Details/5

        public ActionResult Details(int id = 0)
        {
            Genres genres = db.GenresDbSet.Find(id);
            if (genres == null)
            {
                return HttpNotFound();
            }
            return View(genres);
        }

        //
        // GET: /Genre/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Genre/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genres genres)
        {
            if (ModelState.IsValid)
            {
                db.GenresDbSet.Add(genres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genres);
        }

        //
        // GET: /Genre/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Genres genres = db.GenresDbSet.Find(id);
            if (genres == null)
            {
                return HttpNotFound();
            }
            return View(genres);
        }

        //
        // POST: /Genre/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genres genres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //public actionResult Edit(int id =0)
            //genres genre = db.genres.find(id);
            //if (genre ==nul)
            //{
            //return redierect found

            //}

            return View(genres);
        }

        //
        // GET: /Genre/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Genres genres = db.GenresDbSet.Find(id);
            if (genres == null)
            {
                return HttpNotFound();
            }
            return View(genres);
        }

        //
        // POST: /Genre/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genres genres = db.GenresDbSet.Find(id);
            db.GenresDbSet.Remove(genres);
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