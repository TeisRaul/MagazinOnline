using Microsoft.AspNetCore.Mvc;
using Magazin_Online.Models;
using Magazin_Online.Data; // Asigură-te că adaugi namespace-ul corect pentru contextul bazei de date

namespace Magazin_Online.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AppDbContext _context; // Adaugă contextul bazei de date

        public RegisterController(AppDbContext context)
        {
            _context = context;
        }

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
                _context.Utilizator.Add(utilizator);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(utilizator);
        }

    }
}
