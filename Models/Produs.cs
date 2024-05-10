using Magazin_Online.Data.Enums;
using Magazin_Online.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Magazin_Online.Models
{
    public class Produs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Denumirea produsului este obligatorie.")]
        [Display(Name = "Denumire")]
        public string Denumire { get; set; }

        [Required(ErrorMessage = "Categoria produsului este obligatorie.")]
        [Display(Name = "Categorie")]
        public CategorieProdus Categorie { get; set; }

        [Required(ErrorMessage = "Prețul produsului este obligatoriu.")]
        [Display(Name = "Pret")]
        public float Pret { get; set; }

        [Required(ErrorMessage = "Imaginea produsului este obligatorie.")]
        [Display(Name = "Imagine")]
        public string Imagine { get; set; }

        [Required(ErrorMessage = "Descrierea produsului este obligatorie.")]
        [Display(Name = "Descriere")]
        public string Descriere { get; set; }

        [Required(ErrorMessage = "Numărul de bucăți este obligatoriu.")]
        [Display(Name = "Numar Bucati")]
        public int Nr_buc { get; set; }

        [Required(ErrorMessage = "Localitatea este obligatorie.")]
        [Display(Name = "Localitate")]
        public Orase Localitate { get; set; }


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
