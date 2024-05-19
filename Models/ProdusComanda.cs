namespace Magazin_Online.Models
{
    public class ProdusComanda
    {
        public int ProdusId { get; set; }
        public Produs Produs { get; set; }

        public int ComandaId { get; set; }
        public Comanda Comanda { get; set; }

        public int Cantitate { get; set; }
        public decimal Pret { get; set; } 
    }
}
