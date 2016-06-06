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
    public class TVSeriesController : Controller
    {
        private TVSeriesDBContext db = new TVSeriesDBContext();

        // GET: TVSeries
        public ActionResult Index()
        {
            return View(db.TVSeries.ToList());
        }

        // GET: TVSeries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVSeries tVSeries = db.TVSeries.Find(id);
            if (tVSeries == null)
            {
                return HttpNotFound();
            }
            return View(tVSeries);
        }

        // GET: TVSeries/Create
        [Authorize(Users="adminn69@gmail.com")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TVSeries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TVSeriesID,PosterUlr,Title,ReleaseDate,Genre,NumberSeasons")] TVSeries tVSeries)
        {
            if (ModelState.IsValid)
            {
                db.TVSeries.Add(tVSeries);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tVSeries);
        }

        // GET: TVSeries/Edit/5
        [Authorize(Users = "adminn69@gmail.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVSeries tVSeries = db.TVSeries.Find(id);
            if (tVSeries == null)
            {
                return HttpNotFound();
            }
            return View(tVSeries);
        }

        // POST: TVSeries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TVSeriesID,PosterUlr,Title,ReleaseDate,Genre,NumberSeasons")] TVSeries tVSeries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tVSeries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tVSeries);
        }

        // GET: TVSeries/Delete/5
        [Authorize(Users = "adminn69@gmail.com")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVSeries tVSeries = db.TVSeries.Find(id);
            if (tVSeries == null)
            {
                return HttpNotFound();
            }
            return View(tVSeries);
        }

        // POST: TVSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TVSeries tVSeries = db.TVSeries.Find(id);
            db.TVSeries.Remove(tVSeries);
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
