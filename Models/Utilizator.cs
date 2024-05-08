using Magazin_Online.Data.Enums;
using Magazin_Online.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Magazin_Online.Models
{
    public class Utilizator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu")]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "Email-ul este obligatoriu")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola este obligatorie")]
        public string Parola { get; set; }

        [Required(ErrorMessage = "Adresa este obligatorie")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Orasul este obligatoriu")]
        public Orase Oras { get; set; }

        [Required(ErrorMessage = "Numărul de telefon este obligatoriu")]
        public string Telefon { get; set; }

        // Relationship
        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }
        public List<Produs> Produs { get; set; }
        public List<Comanda> Comanda { get; set; }

    }


}

