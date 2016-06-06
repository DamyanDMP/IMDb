using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMDb3._0.Models;

namespace IMDb3._0.Controllers
{
    public class ActorsController : Controller
    {
        private TVSeriesDBContext db = new TVSeriesDBContext();

        // GET: Actors
        public ActionResult Index()
        {
            var actors = db.Actors.Include(a => a.TVSeries);
            return View(actors.ToList());
        }

        // GET: Actors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actors actors = db.Actors.Find(id);
            if (actors == null)
            {
                return HttpNotFound();
            }
            return View(actors);
        }

        // GET: Actors/Create
        [Authorize(Users = "adminn69@gmail.com")]
        public ActionResult Create()
        {
            ViewBag.TVSeriesID = new SelectList(db.TVSeries, "TVSeriesID", "Title");
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActorsID,FirstName,LastName,PictureUrl,LinkUrl,TVSeriesID")] Actors actors)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TVSeriesID = new SelectList(db.TVSeries, "TVSeriesID", "Title", actors.TVSeriesID);
            return View(actors);
        }

        // GET: Actors/Edit/5
        [Authorize(Users = "adminn69@gmail.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actors actors = db.Actors.Find(id);
            if (actors == null)
            {
                return HttpNotFound();
            }
            ViewBag.TVSeriesID = new SelectList(db.TVSeries, "TVSeriesID", "Title", actors.TVSeriesID);
            return View(actors);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActorsID,FirstName,LastName,PictureUrl,LinkUrl,TVSeriesID")] Actors actors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TVSeriesID = new SelectList(db.TVSeries, "TVSeriesID", "PosterUlr", actors.TVSeriesID);
            return View(actors);
        }

        // GET: Actors/Delete/5
        [Authorize(Users = "adminn69@gmail.com")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actors actors = db.Actors.Find(id);
            if (actors == null)
            {
                return HttpNotFound();
            }
            return View(actors);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actors actors = db.Actors.Find(id);
            db.Actors.Remove(actors);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
