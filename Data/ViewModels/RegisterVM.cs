using Magazin_Online.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Magazin_Online.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Numele este obligatoriu.")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu.")]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "Emailul este obligatoriu.")]
        [EmailAddress(ErrorMessage = "Emailul nu este o adresă de email validă.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola este obligatorie.")]
        [DataType(DataType.Password)]
        public string Parola { get; set; }

        [Required(ErrorMessage = "Adresa este obligatorie.")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Orașul este obligatoriu.")]
        public Orase Oras { get; set; }

        [Required(ErrorMessage = "Telefonul este obligatoriu.")]
        [Phone(ErrorMessage = "Telefonul nu este un număr de telefon valid.")]
        public string Telefon { get; set; }

    }
}
