using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using VenteExtension.Models;

namespace VenteExtension.dal
{
    public class VenteContext : DbContext
    {
        public VenteContext() : base("VenteContext")
        {
        }

        public DbSet<Produit> produits { get; set; }
        public DbSet<Commande> commandes { get; set; }
        public DbSet<Client> clients { get; set; }
        //public DbSet<Panier> panier { get; set; }
        //public DbSet<LignePanier> Ligne { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public System.Data.Entity.DbSet<VenteExtension.Models.LignePanier> LignePaniers { get; set; }
    }
}