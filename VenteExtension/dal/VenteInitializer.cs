using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using VenteExtension.Models;

namespace VenteExtension.dal
{
    public class VenteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<VenteContext>
    {
        protected override void Seed(VenteContext context)
        {
            var produits = new List<Produit>
            {
                new Produit{NomExt="Meche Liste noire",Prix_u=75.00,quant=20},
                new Produit { NomExt = "MecheListe blonde", Prix_u = 110.00, quant = 30 },
                new Produit { NomExt = "MecheListe rouge", Prix_u = 90.00, quant = 30 },
            };
            produits.ForEach(s => context.produits.Add(s));
            context.SaveChanges();
            var clients = new List<Client>
            {
                new Client{nomCl="Dupond",prenomCl="jean",tel="0465/55/44/02",mail="jdupond@gmail.com"},
                new Client{nomCl="Dufour",prenomCl="marie",tel="0465/53/42/02",mail="mdufour@gmail.com"},
                new Client{nomCl="Durand",prenomCl="pierre",tel="0466/65/44/02",mail="pdurand@gmail.com"},
                new Client{nomCl="lefour",prenomCl="anne",tel="0467/00/04/55",mail="alefour@gmail.com"},
            };
            clients.ForEach(s => context.clients.Add(s));
            context.SaveChanges();
            var commandes = new List<Commande>
            {
                new Commande{produitID=1,clientID=1,quantCom=1, prixTot=10.00,dateCom=DateTime.Today},
                new Commande{produitID=2,clientID=1,quantCom=1, prixTot=11.00,dateCom=DateTime.Today},
            };
            commandes.ForEach(s => context.commandes.Add(s));
            context.SaveChanges();
        }
    }
}