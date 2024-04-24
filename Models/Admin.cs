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
        public List<Produs> Produs { get; set; }

        //Utilizatori - Un admin poate avea mai mulți utilizatori
        public List<Utilizator> Utilizator { get; set; }
        public int UtilizatorId { get; set; }
        [ForeignKey("UtilizatorId")]

        //Comenzi - Un admin poate avea mai multe comenzi
        public List<Comanda> Comanda { get; set; }
    }
}
