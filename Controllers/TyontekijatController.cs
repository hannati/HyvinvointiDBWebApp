﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hyvinvointisovellus;

namespace Hyvinvointisovellus.Controllers
{
    public class TyontekijatController : Controller
    {
        private HyvinvointiDBEntities db = new HyvinvointiDBEntities();

        // GET: Tyontekijat
        public ActionResult Index()
        {
            return View(db.Tyontekijat.ToList());
        }

        // GET: Tyontekijat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tyontekijat tyontekijat = db.Tyontekijat.Find(id);
            if (tyontekijat == null)
            {
                return HttpNotFound();
            }
            return View(tyontekijat);
        }

        // GET: Tyontekijat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tyontekijat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TyontekijaID,Etuimi,Sukunimi")] Tyontekijat tyontekijat)
        {
            if (ModelState.IsValid)
            {
                db.Tyontekijat.Add(tyontekijat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tyontekijat);
        }

        // GET: Tyontekijat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tyontekijat tyontekijat = db.Tyontekijat.Find(id);
            if (tyontekijat == null)
            {
                return HttpNotFound();
            }
            return View(tyontekijat);
        }

        // POST: Tyontekijat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TyontekijaID,Etuimi,Sukunimi")] Tyontekijat tyontekijat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tyontekijat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tyontekijat);
        }

        // GET: Tyontekijat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tyontekijat tyontekijat = db.Tyontekijat.Find(id);
            if (tyontekijat == null)
            {
                return HttpNotFound();
            }
            return View(tyontekijat);
        }

        // POST: Tyontekijat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tyontekijat tyontekijat = db.Tyontekijat.Find(id);
            db.Tyontekijat.Remove(tyontekijat);
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
