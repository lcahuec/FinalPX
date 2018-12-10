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
    public class REPORTEsController : Controller
    {
        private Ciudad_DollarEntities2 db = new Ciudad_DollarEntities2();

        // GET: REPORTEs
        public ActionResult Index()
        {
            var rEPORTE = db.REPORTE.Include(r => r.CLIENTE1);
            return View(rEPORTE.ToList());
        }

        // GET: REPORTEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPORTE rEPORTE = db.REPORTE.Find(id);
            if (rEPORTE == null)
            {
                return HttpNotFound();
            }
            return View(rEPORTE);
        }

        // GET: REPORTEs/Create
        public ActionResult Create()
        {
            ViewBag.Cliente = new SelectList(db.CLIENTE, "Id", "Nombre");
            return View();
        }

        // POST: REPORTEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cliente,IVA,ISR,AHORRO,MESES,TOTAL")] REPORTE rEPORTE)
        {
            if (ModelState.IsValid)
            {
                db.REPORTE.Add(rEPORTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente = new SelectList(db.CLIENTE, "Id", "Nombre", rEPORTE.Cliente);
            return View(rEPORTE);
        }

        // GET: REPORTEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPORTE rEPORTE = db.REPORTE.Find(id);
            if (rEPORTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente = new SelectList(db.CLIENTE, "Id", "Nombre", rEPORTE.Cliente);
            return View(rEPORTE);
        }

        // POST: REPORTEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cliente,IVA,ISR,AHORRO,MESES,TOTAL")] REPORTE rEPORTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEPORTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente = new SelectList(db.CLIENTE, "Id", "Nombre", rEPORTE.Cliente);
            return View(rEPORTE);
        }

        // GET: REPORTEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPORTE rEPORTE = db.REPORTE.Find(id);
            if (rEPORTE == null)
            {
                return HttpNotFound();
            }
            return View(rEPORTE);
        }

        // POST: REPORTEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REPORTE rEPORTE = db.REPORTE.Find(id);
            db.REPORTE.Remove(rEPORTE);
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
