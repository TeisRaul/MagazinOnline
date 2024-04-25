using Magazin_Online.Data.Enums;
using Magazin_Online.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Magazin_Online.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }

        // Relationship
        public Admin() { }
        public ICollection<Produs> Produs { get; set; }
        public ICollection<Utilizator> Utilizator { get; set; }
        public ICollection<Comanda> Comanda { get; set; }
    }
}