using Magazin_Online.Data.Enums;
using Magazin_Online.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Magazin_Online.Models
{
    public class Produs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] public string Denumire { get; set; }
        [Required] public CategorieProdus Categorie { get; set; }
        [Required] public float Pret { get; set; }
        [Required] public string Imagine { get; set; }
        [Required] public string Descriere { get; set; }
        [Required] public int Nr_buc { get; set; }
        [Required] public Orase Localitate { get; set; }


        // Relationship
        public List<ProdusComanda> ProdusComanda;
        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }
        public int UtilizatorId { get; set; }
        [ForeignKey("UtilizatorId")]
        public Utilizator Utilizator { get; set; }
    }
}
