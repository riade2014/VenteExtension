﻿//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using VenteExtension.Models;
//using VenteExtension.dal;

//namespace VenteExtension.Controllers
//{
//    public class LignePanierController : Controller
//    {
//        private VenteContext db = new VenteContext();

//        // GET: LignePanier
//        public ActionResult Index()
//        {
//            return View(db.LignePaniers.ToList());
//        }

//        // GET: LignePanier/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            LignePanier lignePanier = db.LignePaniers.Find(id);
//            if (lignePanier == null)
//            {
//                return HttpNotFound();
//            }
//            return View(lignePanier);
//        }

//        // GET: LignePanier/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: LignePanier/Create
//        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
//        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        //public ActionResult Create([Bind(Include = "ID,IdProduit,q")] LignePanier lignePanier)
//        public ActionResult Create([Bind(Include = "ID,q")] LignePanier lignePanier)
//        {
//            if (ModelState.IsValid)
//            {
//                db.LignePaniers.Add(lignePanier);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(lignePanier);
//        }

//        // GET: LignePanier/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            LignePanier lignePanier = db.LignePaniers.Find(id);
//            if (lignePanier == null)
//            {
//                return HttpNotFound();
//            }
//            return View(lignePanier);
//        }

//        // POST: LignePanier/Edit/5
//        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
//        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        //public ActionResult Edit([Bind(Include = "ID,IdProduit,q")] LignePanier lignePanier)
//        public ActionResult Edit([Bind(Include = "ID,q")] LignePanier lignePanier)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(lignePanier).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(lignePanier);
//        }

//        // GET: LignePanier/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            LignePanier lignePanier = db.LignePaniers.Find(id);
//            if (lignePanier == null)
//            {
//                return HttpNotFound();
//            }
//            return View(lignePanier);
//        }

//        // POST: LignePanier/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            LignePanier lignePanier = db.LignePaniers.Find(id);
//            db.LignePaniers.Remove(lignePanier);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
