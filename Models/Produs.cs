﻿using Magazin_Online.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magazin_Online.Models
{
    public class Produs
    {
        [Key]
        public int Id { get; set; }

        [Required] public string Denumire {  get; set; }
        [Required] public CategorieProdus Categorie { get; set; }
        [Required] public float Pret { get; set; }
        [Required] public int NumarBucati { get; set; }
        [Required] public string Descriere { get; set; }
        [Required] public string Imagine { get; set; }
        [Required] public Orase Orase { get; set; }

        //Relationships
        public List<ProdusComanda> ProdusComanda { get; set; }

        //Utilizator
        public int UtilizatorId { get; set; }
        [ForeignKey("UtilizatorId")]
        public Utilizator Utilizator { get; set; }

        //Admin
        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }

        public int ComandaId { get; set; }
        [ForeignKey("ComandaId")]
        public Comanda Comanda { get; set; }

    }
}
