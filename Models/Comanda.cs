using System.ComponentModel.DataAnnotations;

namespace Magazin_Online.Models
{
    public class Comanda
    {
        [Key]
        public int Id { get; set; }
        [Required] public string Nr_comanda { get; set; }
        [Required] public int Nr_buc { get; set; }
        [Required] public DateTime DataComanda { get; set; }
        //[Required] public StareComanda StareComanda { get; set; }
    }
}
