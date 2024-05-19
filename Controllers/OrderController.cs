using Magazin_Online.Data;
using Magazin_Online.Data.Enums;
using Magazin_Online.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;

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

        public async Task<IActionResult> Details(string nrComanda)
        {
            if (string.IsNullOrEmpty(nrComanda))
            {
                return BadRequest();
            }

            var order = await _context.Comanda
                .Include(c => c.ProdusComanda)
                .ThenInclude(pc => pc.Produs)
                .Include(c => c.Utilizator)
                .FirstOrDefaultAsync(c => c.NrComanda == nrComanda);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
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

        public async Task<IActionResult> MyOrders()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userOrders = _context.Comanda
                .Where(c => c.UtilizatorId == int.Parse(userId))
                .ToList();

            return View(userOrders);
        }

        private void ClearCart()
        {
            HttpContext.Session.Remove("Cart");
        }

        private async Task<string> GenerateUniqueOrderNumberAsync()
        {
            var random = new Random();
            string orderNumber;

            do
            {
                orderNumber = random.Next(1000, 10000).ToString();
            }
            while (await _context.Comanda.AnyAsync(c => c.NrComanda == orderNumber));

            return orderNumber;
        }


        public async Task<IActionResult> FinalizeOrder()
        {
            var nrComanda = await GenerateUniqueOrderNumberAsync();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            var utilizator = await _context.Utilizator.FindAsync(int.Parse(userId));

            var cartProducts = GetCartItems();

            if (!cartProducts.Any())
            {
                ModelState.AddModelError("", "Your shopping cart is empty.");
                return RedirectToAction("Index", "ShoppingCart");
            }

            var nrBucati = cartProducts.Sum(c => c.Nr_buc);

            var comanda = new Comanda
            {
                NrComanda = nrComanda,
                NrBuc = nrBucati,
                DataComanda = DateTime.Now,
                StareComanda = StareComanda.InAsteptare,
                UtilizatorId = int.Parse(userId),
                AdminId = 1
            };

            _context.Comanda.Add(comanda);
            await _context.SaveChangesAsync();

            var comandaId = comanda.Id;

            foreach (var item in cartProducts)
            {
                var produsComanda = new ProdusComanda
                {
                    ComandaId = comandaId,
                    ProdusId = item.Id,
                    Cantitate = item.Nr_buc,
                    Pret = (decimal)item.Pret
                };

                _context.ProdusComanda.Add(produsComanda);
            }

            await _context.SaveChangesAsync();

            ClearCart();

            return RedirectToAction("MyOrders");
        }



    }
}
