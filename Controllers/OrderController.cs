using Magazin_Online.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magazin_Online.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Comanda.ToListAsync();
            return View();
        }

        //public async Task<IActionResult> ShoppingCart()
        //{
        //    var cartItems = await _context.ShoppingCartItem.ToListAsync();

        //    // Pentru fiecare element din coș, adăugăm informațiile despre produs
        //    foreach (var item in cartItems)
        //    {
        //        // Obținem informațiile despre produs folosind ProductId
        //        var product = await _context.Produs.FindAsync(item.ProductId);

        //        // Dacă găsim produsul, îl adăugăm în ShoppingCartItem
        //        if (product != null)
        //        {
        //            item.Produs = product;
        //        }
        //    }

        //    // Calculăm numărul total de produse din coș
        //    var cartItemsCount = cartItems.Sum(item => item.Quantity);

        //    // Adăugăm numărul de produse în ViewBag pentru a fi accesat în View
        //    ViewBag.CartItemCount = cartItemsCount;

        //    return View(cartItems);
        //}


    }
}
