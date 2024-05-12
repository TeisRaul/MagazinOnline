using Magazin_Online.Data.Enums;

namespace Magazin_Online.Models
{
    public class EditVM
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public Orase Oras { get; set; }
        public string Telefon { get; set; }
    }
}
