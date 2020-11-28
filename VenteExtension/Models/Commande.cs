using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenteExtension.Models
{
    public class Commande
    {
        public int commandeID { get; set; }
        public int produitID { get; set; }
        public int clientID { get; set; }
        public int quantCom { get; set; }
        public double prixTot { get; set; }
        public DateTime dateCom { get; set; } = DateTime.Now;

        public virtual Produit produit { get; set; }
        public virtual Client client { get; set; }
        public double calculPrixTot()
        {
            prixTot = quantCom * produit.Prix_u;
            return prixTot;
        }
       /* public DateTime dateDuJour()
        {
            dateCom = DateTime.Now;
            return dateCom;
        }*/
    }
}