using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenP10.Models;

namespace ExamenP10.Controllers
{
    public class PIBController : Controller
    {
        private Ciudad_DollarEntities2 db = new Ciudad_DollarEntities2();

        // GET: PIB
        public ActionResult Index()
        {
            return View(db.PIB.ToList());
        }

        // GET: PIB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PIB pIB = db.PIB.Find(id);
            if (pIB == null)
            {
                return HttpNotFound();
            }
            return View(pIB);
        }

        // GET: PIB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PIB/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PIB1")] PIB pIB)
        {
            if (ModelState.IsValid)
            {
                db.PIB.Add(pIB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pIB);
        }

        // GET: PIB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PIB pIB = db.PIB.Find(id);
            if (pIB == null)
            {
                return HttpNotFound();
            }
            return View(pIB);
        }

        // POST: PIB/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PIB1")] PIB pIB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pIB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pIB);
        }

        // GET: PIB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PIB pIB = db.PIB.Find(id);
            if (pIB == null)
            {
                return HttpNotFound();
            }
            return View(pIB);
        }

        // POST: PIB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PIB pIB = db.PIB.Find(id);
            db.PIB.Remove(pIB);
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
