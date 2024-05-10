using Magazin_Online.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Magazin_Online.Models
{
    public class ProdusVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Denumirea produsului este obligatorie")]
        public string Denumire { get; set; }

        [Required(ErrorMessage = "Categorie este obligatorie")]
        public CategorieProdus Categorie { get; set; }

        [Required(ErrorMessage = "Prețul este obligatoriu")]
        public decimal Pret { get; set; }

        [Required(ErrorMessage = "Descrierea este obligatorie")]
        public string Descriere { get; set; }

        [Required(ErrorMessage = "Numărul de bucăți este obligatoriu")]
        public int Nr_buc { get; set; }

        [Required(ErrorMessage = "Localitatea este obligatorie")]
        public Orase Localitate { get; set; }

        // Adăugăm un câmp pentru imagine
        public string Imagine { get; set; }
    }
}
