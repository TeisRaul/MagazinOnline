using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Magazin_Online.Models
{
    public class Utilizator
    {
        [Key]
        public int Id { get; set; }

        [Required] public string Nume { get; set; }
        [Required] public string Prenume { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Parola { get; set; }
        [Required] public string Adresa { get; set; }
        //[Required] public Orase Oras { get; set; }
        [Required] public string Telefon { get; set; }
    }
}
