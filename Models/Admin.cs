using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magazin_Online.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }

        //Relationship

        //Produs
        public int ProdusId { get; set; }
        [ForeignKey("ProdusId")]
        public Produs Produs { get; set; }

        //Utilizator
        public int UtilizatorId { get; set; }
        [ForeignKey("UtilizatorId")]
        public Utilizator Utilizator { get; set; }

        //Comanda
        public int ComandaId { get; set; }
        [ForeignKey("ComandaId")]
        public Comanda Comanda { get; set; }
    }
}
