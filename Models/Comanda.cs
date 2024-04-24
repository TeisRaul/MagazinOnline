using Magazin_Online.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magazin_Online.Models
{
    public class Comanda
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NrComanda { get; set; }

        [Required]
        public int NrBuc { get; set; }

        [Required]
        public DateTime DataComanda { get; set; }

        [Required]
        public StareComanda StareComanda { get; set; }

        // Relationship

        // O comandă poate fi asociată cu un singur Admin
        public int? AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }

        // O comandă poate fi asociată cu un singur Utilizator
        public int UtilizatorId { get; set; }
        [ForeignKey("UtilizatorId")]
        public Utilizator Utilizator { get; set; }

        // O comandă poate conține mai multe produse
        public List<ProdusComanda> ProdusComanda { get; set; }
    }
}
