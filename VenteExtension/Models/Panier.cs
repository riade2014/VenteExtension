using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenteExtension.Models
{
    public class Panier
    {
        public int panierID { get; set; }
        public int commandeID { get; set; }
        public int produitID { get; set; }
        public int clientID { get; set; }
        public decimal prixTotcli { get; set; }

        public virtual Produit produit { get; set; }
        public virtual Client client { get; set; }
        public virtual Commande commande { get; set; }
    }
}