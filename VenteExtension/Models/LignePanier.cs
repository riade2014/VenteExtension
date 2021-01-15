using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenteExtension.dal;

namespace VenteExtension.Models
{
    public class LignePanier : IDisposable
    {
        public int ID { get; set; }
        public int IdProduit { get; set; }
        public int IdClient { get; set; }
        public int IdCommande { get; set; }
        public int q { get; set; }
        //public decimal montantCli { get; set; }
        public virtual ICollection<Produit> Produits { get; set; }
        public virtual Commande commande { get; set; }
        private VenteContext _context;
        public LignePanier(VenteContext context, int commandeID)
        {
            _context = context;
            IdCommande = commandeID;
        }
        public void ajout(int idProduit)
        {
            Commande com = _context.commandes.SingleOrDefault(s => s.commandeID == IdCommande && s.produitID == idProduit);
            if (com == null)
            {
                com = new Commande
                {
                    commandeID = IdCommande,
                    produitID = idProduit,
                    quantCom = 1
                };
                _context.commandes.Add(com);
            }
            else
            {
                com.quantCom++;
            }
            _context.SaveChanges();
        }

        public void supprimer(int comID)
        {
            Commande c = _context.commandes.SingleOrDefault(s => s.commandeID == comID);
            if (c != null)
            {
                _context.commandes.Remove(c);
                _context.SaveChanges();
            }
        }

        public Commande ligne(int comID)
        {
            return _context.commandes.FirstOrDefault(p => p.commandeID == comID);
        }

        public IList<Commande> ligne()
        {
            IList<Commande> ls = (IList<Commande>)_context.commandes.Where(s => s.commandeID == IdCommande).Select(s => s.produitID).ToList();
            return ls;
        }

        public decimal Total()
        {
            decimal T = _context.commandes.Where(s => s.commandeID == IdCommande).Select(s => s.produitID).Sum();
            return T;
        }
        public int Nombre()
        {
            int n = _context.commandes.Where(s => s.commandeID == IdCommande).ToList().Count;
            return n;
        }

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
        
    }
}