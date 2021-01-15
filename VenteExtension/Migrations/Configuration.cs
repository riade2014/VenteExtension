namespace VenteExtension.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VenteExtension.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<VenteExtension.dal.VenteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VenteExtension.dal.VenteContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var clients = new List<Client>
            {
                new Client { nomCl = "Carson",   prenomCl = "Alexander",
                    tel = "0467/550225" }
            };
            clients.ForEach(s => context.clients.AddOrUpdate(p => p.nomCl, s));
            context.SaveChanges();

            var produits = new List<Produit>
            {
                new Produit {NomExt = "Indienne",  Prix_u = 115 , quant=9 }
            };
            produits.ForEach(s => context.produits.AddOrUpdate(p => p.NomExt, s));
            context.SaveChanges();

            var commandes = new List<Commande>
            {
                new Commande {
                    clientID = clients.Single(s => s.nomCl == "Carson").clientID,
                    produitID = produits.Single(c => c.NomExt == "Indienne" ).ID,
                    quantCom = 1 , prixTot= 115, dateCom= DateTime.Now
                }
            };

            foreach (Commande c in commandes)
            {
                var commandeInDataBase = context.commandes.Where(
                    s =>
                         s.client.clientID == c.clientID &&
                         s.produit.ID == c.produitID).SingleOrDefault();
                if (commandeInDataBase == null)
                {
                    context.commandes.Add(c);
                }
            }
            context.SaveChanges();

        }
    }
}
