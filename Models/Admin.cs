using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magazin_Online.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        // Relații one-to-many

        // Un Admin poate avea mai multe produse
        public List<Produs> Produs { get; set; }

        // Un Admin poate avea mai mulți utilizatori
        public List<Utilizator> Utilizator { get; set; }

        // Un Admin poate avea mai multe comenzi
        public List<Comanda> Comanda{ get; set; }
    }
}
