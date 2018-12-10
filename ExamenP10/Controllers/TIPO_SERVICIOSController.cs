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
    public class TIPO_SERVICIOSController : Controller
    {
        private Ciudad_DollarEntities2 db = new Ciudad_DollarEntities2();

        // GET: TIPO_SERVICIOS
        public ActionResult Index()
        {
            return View(db.TIPO_SERVICIOS.ToList());
        }

        // GET: TIPO_SERVICIOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_SERVICIOS tIPO_SERVICIOS = db.TIPO_SERVICIOS.Find(id);
            if (tIPO_SERVICIOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_SERVICIOS);
        }

        // GET: TIPO_SERVICIOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_SERVICIOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,porcentaje")] TIPO_SERVICIOS tIPO_SERVICIOS)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_SERVICIOS.Add(tIPO_SERVICIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_SERVICIOS);
        }

        // GET: TIPO_SERVICIOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_SERVICIOS tIPO_SERVICIOS = db.TIPO_SERVICIOS.Find(id);
            if (tIPO_SERVICIOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_SERVICIOS);
        }

        // POST: TIPO_SERVICIOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,porcentaje")] TIPO_SERVICIOS tIPO_SERVICIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_SERVICIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_SERVICIOS);
        }

        // GET: TIPO_SERVICIOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_SERVICIOS tIPO_SERVICIOS = db.TIPO_SERVICIOS.Find(id);
            if (tIPO_SERVICIOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_SERVICIOS);
        }

        // POST: TIPO_SERVICIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_SERVICIOS tIPO_SERVICIOS = db.TIPO_SERVICIOS.Find(id);
            db.TIPO_SERVICIOS.Remove(tIPO_SERVICIOS);
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
