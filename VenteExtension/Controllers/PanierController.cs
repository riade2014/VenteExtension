using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VenteExtension.Models;
using VenteExtension.dal;

namespace VenteExtension.Controllers
{
    public class PanierController : Controller
    {
        private VenteContext db = new VenteContext();

        // GET: Panier
        public ActionResult Index()
        {
            var paniers = db.paniers.Include(p => p.client).Include(p => p.produit);
            return View(paniers.ToList());
        }

        // GET: Panier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Panier panier = db.paniers.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            return View(panier);
        }

        // GET: Panier/Create
        public ActionResult Create()
        {
            ViewBag.clientID = new SelectList(db.clients, "clientID", "nomCl");
            ViewBag.produitID = new SelectList(db.produits, "ID", "NomExt");
            return View();
        }

        // POST: Panier/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "panierID,commandeID,produitID,clientID,quantCom,prixTot,dateCom")] Panier panier)
        {
            if (ModelState.IsValid)
            {
                db.paniers.Add(panier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clientID = new SelectList(db.clients, "clientID", "nomCl", panier.clientID);
            ViewBag.produitID = new SelectList(db.produits, "ID", "NomExt", panier.produitID);
            return View(panier);
        }

        // GET: Panier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Panier panier = db.paniers.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            ViewBag.clientID = new SelectList(db.clients, "clientID", "nomCl", panier.clientID);
            ViewBag.produitID = new SelectList(db.produits, "ID", "NomExt", panier.produitID);
            return View(panier);
        }

        // POST: Panier/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "panierID,commandeID,produitID,clientID,quantCom,prixTot,dateCom")] Panier panier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(panier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clientID = new SelectList(db.clients, "clientID", "nomCl", panier.clientID);
            ViewBag.produitID = new SelectList(db.produits, "ID", "NomExt", panier.produitID);
            return View(panier);
        }

        // GET: Panier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Panier panier = db.paniers.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            return View(panier);
        }

        // POST: Panier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Panier panier = db.paniers.Find(id);
            db.paniers.Remove(panier);
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
