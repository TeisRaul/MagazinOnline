using Magazin_Online.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Magazin_Online.Data.ViewModels
{
    public class EditVM
    {
        [Required(ErrorMessage = "Numele este obligatoriu")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu")]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "Email-ul este obligatoriu")]
        [EmailAddress(ErrorMessage = "Adresa de email nu este validă")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Adresa este obligatorie")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Orasul este obligatoriu")]
        public Orase Oras { get; set; }

        [Required(ErrorMessage = "Numărul de telefon este obligatoriu")]
        [Phone(ErrorMessage = "Numărul de telefon nu este valid")]
        public string Telefon { get; set; }
    }
}
