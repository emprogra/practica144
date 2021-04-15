using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class GentesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Gentes
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Gentes.ToList());
        }

        // GET: Gentes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gente gente = db.Gentes.Find(id);
            if (gente == null)
            {
                return HttpNotFound();
            }
            return View(gente);
        }

        // GET: Gentes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerosnId,Name,CovidCount")] Gente gente)
        {
            if (ModelState.IsValid)
            {
                db.Gentes.Add(gente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gente);
        }

        // GET: Gentes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gente gente = db.Gentes.Find(id);
            if (gente == null)
            {
                return HttpNotFound();
            }
            return View(gente);
        }

        // POST: Gentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerosnId,Name,CovidCount")] Gente gente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gente);
        }

        // GET: Gentes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gente gente = db.Gentes.Find(id);
            if (gente == null)
            {
                return HttpNotFound();
            }
            return View(gente);
        }

        // POST: Gentes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gente gente = db.Gentes.Find(id);
            db.Gentes.Remove(gente);
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
