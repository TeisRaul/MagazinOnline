using Magazin_Online.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Magazin_Online.Models
{
    public class Produs
    {
        [Key]
        public int Id { get; set; }

        [Required] public string Denumire {  get; set; }
        [Required] public CategorieProdus Categorie { get; set; }
        [Required] public float Pret { get; set; }
        [Required] public int NumarBucati { get; set; }
        [Required] public string Descriere { get; set; }
        [Required] public string Imagine { get; set; }
        [Required] public Orase Orase { get; set; }

        //Relationships
        public List<ProdusComanda> ProdusComanda { get; set; }

    }
}
