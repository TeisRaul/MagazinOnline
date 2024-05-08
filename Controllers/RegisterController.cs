using Microsoft.AspNetCore.Mvc;
using Magazin_Online.Models;
using Magazin_Online.Data;

namespace Magazin_Online.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AppDbContext _context;

        public RegisterController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Utilizator utilizator)
        {
            if (ModelState.IsValid)
            {
                // Adăugăm utilizatorul către contextul bazei de date și salvăm modificările
                _context.Utilizator.Add(utilizator);
                _context.SaveChanges();

                // Redirecționăm către pagina de start sau altă pagină după înregistrare
                return RedirectToAction("Index", "Home");
            }

            // Dacă modelul nu este valid, afișăm pagina de înregistrare cu erorile corespunzătoare
            return View(utilizator);
        }
    }
}
