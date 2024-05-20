using Magazin_Online.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Magazin_Online.Data.ViewModels
{
    public class ProdusVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Denumirea produsului este obligatorie")]
        public string Denumire { get; set; }

        [Required(ErrorMessage = "Categoria produsului este obligatorie")]
        public CategorieProdus Categorie { get; set; }

        [Required(ErrorMessage = "Prețul este obligatoriu")]
        public float Pret { get; set; }

        [Required(ErrorMessage = "Descrierea este obligatorie")]
        public string Descriere { get; set; }

        [Required(ErrorMessage = "Numărul de bucăți este obligatoriu")]
        public int Nr_buc { get; set; }

        [Required(ErrorMessage = "Localitatea este obligatorie")]
        public Orase Localitate { get; set; }

        public string Imagine { get; set; }

        [Required(ErrorMessage = "Imaginea este obligatorie")]
        public IFormFile ImageFile { get; set; }
    }

}
