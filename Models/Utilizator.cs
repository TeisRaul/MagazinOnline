using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Magazin_Online.Data.Enums;

namespace Magazin_Online.Models
{
    public class Utilizator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nume { get; set; }

        [Required]
        public string Prenume { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Parola { get; set; }

        [Required]
        public string Adresa { get; set; }

        [Required]
        public Orase Oras { get; set; }

        [Required]
        public string Telefon { get; set; }

        // Relationship

        // Un Utilizator poate plasa mai multe comenzi
        public List<Comanda> Comanda { get; set; }

        // Un Utilizator poate avea mai multe produse
        public List<Produs> Produs { get; set; }

        // Un Utilizator este asociat cu un Admin
        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }
    }
}
