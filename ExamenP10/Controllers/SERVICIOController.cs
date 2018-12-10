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
    public class SERVICIOController : Controller
    {
        private Ciudad_DollarEntities2 db = new Ciudad_DollarEntities2();

        // GET: SERVICIO
        public ActionResult Index()
        {
            var sERVICIO = db.SERVICIO.Include(s => s.TIPO_SERVICIOS);
            return View(sERVICIO.ToList());
        }

        // GET: SERVICIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO);
        }

        // GET: SERVICIO/Create
        public ActionResult Create()
        {
            ViewBag.Tipo_Servicio = new SelectList(db.TIPO_SERVICIOS, "Id", "Descripcion");
            return View();
        }

        // POST: SERVICIO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo_Servicio")] SERVICIO sERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.SERVICIO.Add(sERVICIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo_Servicio = new SelectList(db.TIPO_SERVICIOS, "Id", "Descripcion", sERVICIO.Tipo_Servicio);
            return View(sERVICIO);
        }

        // GET: SERVICIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo_Servicio = new SelectList(db.TIPO_SERVICIOS, "Id", "Descripcion", sERVICIO.Tipo_Servicio);
            return View(sERVICIO);
        }

        // POST: SERVICIO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo_Servicio")] SERVICIO sERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sERVICIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo_Servicio = new SelectList(db.TIPO_SERVICIOS, "Id", "Descripcion", sERVICIO.Tipo_Servicio);
            return View(sERVICIO);
        }

        // GET: SERVICIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO);
        }

        // POST: SERVICIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            db.SERVICIO.Remove(sERVICIO);
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
