using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenteExtension.dal;

namespace VenteExtension.Models
{
    public class Commande
    {
        public int commandeID { get; set; }
        public int produitID { get; set; }
        public int clientID { get; set; }
        public int quantCom { get; set; }
        public decimal prixTot { get; set; }
        public DateTime dateCom { get; set; } = DateTime.Now;
        public virtual Produit produit { get; set; }
        public virtual Client client { get; set; }
        //public virtual LignePanier Ligne { get; set; }
        public decimal calculPrixTot()
        {
            //return prixTot = quantCom * (decimal)produit.Prix_u;
            //return prixTot;
            return prixTot = quantCom *produit.Prix_u;
        }
        public Boolean verifQuant()
        {
            if (quantCom > 0)
            {
                return true;
            }
            else return false;
        }
    }
}