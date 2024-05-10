using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Magazin_Online.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Produs Produs { get; set; }
        public int Cantitate { get; set; }


        public string ShoppingCartId { get; set; }
    }
}
