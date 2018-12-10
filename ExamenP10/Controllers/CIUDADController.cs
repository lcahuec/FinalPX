﻿using System;
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
    public class CIUDADController : Controller
    {
        private Ciudad_DollarEntities2 db = new Ciudad_DollarEntities2();

        // GET: CIUDAD
        public ActionResult Index()
        {
            return View(db.CIUDAD.ToList());
        }

        // GET: CIUDAD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CIUDAD cIUDAD = db.CIUDAD.Find(id);
            if (cIUDAD == null)
            {
                return HttpNotFound();
            }
            return View(cIUDAD);
        }

        // GET: CIUDAD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CIUDAD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion")] CIUDAD cIUDAD)
        {
            if (ModelState.IsValid)
            {
                db.CIUDAD.Add(cIUDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cIUDAD);
        }

        // GET: CIUDAD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CIUDAD cIUDAD = db.CIUDAD.Find(id);
            if (cIUDAD == null)
            {
                return HttpNotFound();
            }
            return View(cIUDAD);
        }

        // POST: CIUDAD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] CIUDAD cIUDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cIUDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cIUDAD);
        }

        // GET: CIUDAD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CIUDAD cIUDAD = db.CIUDAD.Find(id);
            if (cIUDAD == null)
            {
                return HttpNotFound();
            }
            return View(cIUDAD);
        }

        // POST: CIUDAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CIUDAD cIUDAD = db.CIUDAD.Find(id);
            db.CIUDAD.Remove(cIUDAD);
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
