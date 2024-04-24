using System.ComponentModel.DataAnnotations;

namespace Magazin_Online.Models
{
    public class Produs
    {
        [Key]
        public int Id { get; set; }

        public string Denumire {  get; set; }
        //public CategorieProdus Categorie { get; set; }
        public float Pret { get; set; }
        public int NumarBucati { get; set; }
        public string Descriere { get; set; }
        public string Imagine { get; set; }
        //public Orase Orase { get; set; }

    }
}
