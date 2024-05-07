using Microsoft.AspNetCore.Mvc;
using Magazin_Online.Models;
using Magazin_Online.Data; // Asigură-te că adaugi namespace-ul corect pentru contextul bazei de date

namespace Magazin_Online.Controllers
{
    public class ARegisterController : Controller
    {
        private readonly AppDbContext _context; // Adaugă contextul bazei de date

        public ARegisterController(AppDbContext context)
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
        public IActionResult Register(Utilizator model)
        {
            if (ModelState.IsValid)
            {
                // Crează un nou Utilizator și adaugă-l în baza de date
                var user = new Utilizator
                {
                    Nume = model.Nume,
                    Prenume = model.Prenume,
                    Email = model.Email,
                    Parola = model.Parola,
                    Adresa = model.Adresa,
                    Oras = model.Oras,
                    Telefon = model.Telefon
                };

                _context.Utilizator.Add(user);
                _context.SaveChanges();

                // După ce utilizatorul este creat, poți redirecționa către o pagină de confirmare a înregistrării sau direct către pagina principală
                return RedirectToAction("Index", "Home");
            }

            // Dacă modelul nu este valid, afișează din nou pagina de înregistrare cu erorile corespunzătoare
            return View(model);
        }
    }
}
