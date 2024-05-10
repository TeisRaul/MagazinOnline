using Magazin_Online.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Magazin_Online.Models
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "The Surname field is required.")]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [DataType(DataType.Password)]
        public string Parola { get; set; }

        [Required(ErrorMessage = "The Address field is required.")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "The City field is required.")]
        public Orase Oras { get; set; }

        [Required(ErrorMessage = "The Phone field is required.")]
        [Phone(ErrorMessage = "The Phone field is not a valid phone number.")]
        public string Telefon { get; set; }
    }
}
