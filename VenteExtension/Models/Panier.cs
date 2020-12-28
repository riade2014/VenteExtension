//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Data;
//using System.Data.Entity;
//using System.Collections;
//    namespace VenteExtension.Models
//{
//    public class Panier : IDisposable
//    {
//        private Db _context;
//        private String _panierID;
//        public Panier(DbSet context, String panierID)
//        {
//            _context = context;
//            _panierID = panierID;
//        }
//        public void Ajouter(int IDproduit)
//        {
//            //LignePanier ligne = _context.Find()
//            LignePanier Ligne = _context.LignePanier.SingleOrDefault(s => s.panierID == _panierID && s.IdProduit == IDproduit);
//            if (_context== null)
//            {
//                Ligne = new LignePanier
//                {
//                    panierID = _panierID,
//                    IdProduit = IDproduit,
//                    q = 1,
//                };
//                _context.LignePnier.Add(Ligne);
//            }
//            else
//                Ligne.q++;
//            _context.SaveChange();
//        }
//       public void Dispose()
//        {
//            if (_context != null)
//            {
//                _context.Dispose();
//                _context = null;
//            }
//        }
//    }
//}