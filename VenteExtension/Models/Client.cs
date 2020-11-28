using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VenteExtension.Models
{
    public class Client
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int clientID { get; set; }
        public string nomCl { get; set; }
        public string prenomCl { get; set; }
        public string tel { get; set; }
        public string mail { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
    }
}