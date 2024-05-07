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

         public string Nume { get; set; }
         public string Prenume { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Parola { get; set; }
         public string Adresa { get; set; }
         public Orase Oras { get; set; }
         public string Telefon { get; set; }

        // Relationship
        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }
        public List<Produs> Produs { get; set; }
        public List<Comanda> Comanda { get; set; }

    }


}

