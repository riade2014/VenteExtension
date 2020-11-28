using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VenteExtension.Models
{
    public class Produit
    {
        [Key]
        public int ID { get; set; }
        public string NomExt { get; set; }
        public double Prix_u { get; set; }
        public int quant { get; set; }


        public virtual ICollection<Commande> commandes { get; set; }
    }
}