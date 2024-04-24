using Magazin_Online.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magazin_Online.Models
{
    public class Comanda
    {
        [Key]
        public int Id { get; set; }
        [Required] public string Nr_comanda { get; set; }
        [Required] public int Nr_buc { get; set; }
        [Required] public DateTime DataComanda { get; set; }
        [Required] public StareComanda StareComanda { get; set; }

        public List<ProdusComanda> ProdusComanda { get; set; }
        public Admin Admin { get; set; }
        public int UtilizatorId { get; set; }
        [ForeignKey("UtilizatorId")]
        public Utilizator Utilizator { get; set; }
        public List<Produs> Produs { get; set; }

    }
}
