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

namespace VenteExtension
{
    public class CommandeController : Controller
    {
        private VenteContext db = new VenteContext();

        // GET: Commande
        public ActionResult Index()
        {
            var commandes = db.commandes.Include(c => c.client).Include(c => c.produit);
            return View(commandes.ToList());
        }

        // GET: Commande/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // GET: Commande/Create
        public ActionResult Create()
        {
            ViewBag.clientID = new SelectList(db.clients, "clientID", "nomCl");
            ViewBag.produitID = new SelectList(db.produits, "ID", "NomExt");
            return View();
        }

        // POST: Commande/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "commandeID,produitID,clientID,quantCom,prixTot,dateCom")] Commande commande)
        public ActionResult Create([Bind(Include = "commandeID,produitID,clientID,quantCom,prixTot,dateCom,prix_u")] Commande commande)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // commande.dateCom = commande.dateDuJour();
                    commande.dateCom = commande.dateCom;
                    Produit produit = db.produits.Find(commande.produitID);
                    commande.produit = produit;
                    commande.prixTot = commande.calculPrixTot();
                    db.commandes.Add(commande);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            ViewBag.clientID = new SelectList(db.clients, "clientID", "nomCl", commande.clientID);
            ViewBag.produitID = new SelectList(db.produits, "ID", "NomExt", commande.produitID);
            return View(commande);
        }

        // GET: Commande/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            ViewBag.clientID = new SelectList(db.clients, "clientID", "nomCl", commande.clientID);
            ViewBag.produitID = new SelectList(db.produits, "ID", "NomExt", commande.produitID);
            return View(commande);
        }

        // POST: Commande/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "commandeID,produitID,clientID,quantCom,prixTot,dateCom")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                //commande.dateCom = commande.dateDuJour();
                commande.dateCom = commande.dateCom;
                Produit produit = db.produits.Find(commande.produitID);
                commande.produit = produit;
                commande.prixTot = commande.calculPrixTot();
                db.Entry(commande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clientID = new SelectList(db.clients, "clientID", "nomCl", commande.clientID);
            ViewBag.produitID = new SelectList(db.produits, "ID", "NomExt", commande.produitID);
            return View(commande);
        }

        // GET: Commande/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = db.commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // POST: Commande/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commande commande = db.commandes.Find(id);
            db.commandes.Remove(commande);
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
