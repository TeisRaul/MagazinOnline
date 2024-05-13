using Magazin_Online.Data;
using Magazin_Online.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        public List<Produs> GetCartItems()
        {
            var cart = HttpContext.Session.GetString("Cart");

            if (string.IsNullOrEmpty(cart))
            {
                return new List<Produs>();
            }
            else
            {
                return JsonConvert.DeserializeObject<List<Produs>>(cart);
            }
        }
        public async Task<IActionResult> ShoppingCart()
        {
            var cartItems = GetCartItems(); 
            return View(cartItems);
        }

        [HttpPost]
        public IActionResult AddItemToShoppingCart(int productId, int quantity)
        {
            var product = _context.Produs.Find(productId);

            if (product == null)
            {
                return NotFound();
            }

            if (quantity > product.Nr_buc)
            {
                TempData["ErrorMessage"] = "Cantitatea introdusă depășește stocul disponibil.";
                return RedirectToAction("ShoppingCart");
            }

            var cart = HttpContext.Session.Get<List<Produs>>("Cart") ?? new List<Produs>();

            cart.Add(new Produs
            {
                Id = product.Id,
                Denumire = product.Denumire,
                Pret = product.Pret,
                Nr_buc = quantity
            });

            HttpContext.Session.Set("Cart", cart);

            return RedirectToAction("ShoppingCart");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = HttpContext.Session.Get<List<Produs>>("Cart") ?? new List<Produs>();
            var productToRemove = cart.FirstOrDefault(p => p.Id == productId);

            if (productToRemove != null)
            {
                cart.Remove(productToRemove);
                HttpContext.Session.Set("Cart", cart);

                var product = _context.Produs.Find(productId);
                _context.SaveChanges();
            }

            return RedirectToAction("ShoppingCart");
        }

        [HttpPost]
        public IActionResult UpdateCart(Dictionary<int, int> quantities)
        {
            var cart = HttpContext.Session.Get<List<Produs>>("Cart") ?? new List<Produs>();

            foreach (var (productId, quantity) in quantities)
            {
                var productInCart = cart.FirstOrDefault(p => p.Id == productId);
                if (productInCart != null)
                {
                    var product = _context.Produs.Find(productId);
                    var oldQuantity = productInCart.Nr_buc;
                    var newQuantity = quantity;

                    if (newQuantity > oldQuantity)
                    {
                        var difference = newQuantity - oldQuantity;
                        if (difference <= product.Nr_buc)
                        {
                            product.Nr_buc -= difference;
                            productInCart.Nr_buc = newQuantity;
                        }
                    }
                    else if (newQuantity < oldQuantity)
                    {
                        var difference = oldQuantity - newQuantity;
                        product.Nr_buc += difference;
                        productInCart.Nr_buc = newQuantity;
                    }
                }
            }

            _context.SaveChanges();
            HttpContext.Session.Set("Cart", cart);
            return RedirectToAction("ShoppingCart");
        }


    }
}
