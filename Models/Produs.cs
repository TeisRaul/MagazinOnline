using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Magazin_Online.Data.Enums;

namespace Magazin_Online.Models
{
    public class Produs
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Denumire { get; set; }

        [Required]
        public CategorieProdus Categorie { get; set; }

        [Required]
        public float Pret { get; set; }

        [Required]
        public int NumarBucati { get; set; }

        [Required]
        public string Descriere { get; set; }

        [Required]
        public string Imagine { get; set; }

        [Required]
        public Orase Orase { get; set; }

        // Relationship

        // Un Produs poate fi legat de un Utilizator
        public int UtilizatorId { get; set; }
        [ForeignKey("UtilizatorId")]
        public Utilizator Utilizator { get; set; }

        // Un Produs poate fi legat de un Admin
        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }

        // Un Produs poate fi parte din mai multe comenzi
        public List<ProdusComanda> ProdusComanda { get; set; }
    }
}
