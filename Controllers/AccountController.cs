using Microsoft.AspNetCore.Mvc;
using Magazin_Online.Models; // presupunând că modelul tău de utilizator se numește UserModel
using System.Linq;
using Microsoft.AspNetCore.Http;
using Magazin_Online.Data;

namespace Magazin_Online.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Utilizator model)
        {
            if (ModelState.IsValid)
            {
                // Verifică dacă există un utilizator cu email-ul și parola introduse
                var user = _context.Utilizator.FirstOrDefault(u => u.Email == model.Email && u.Parola == model.Parola);

                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Autentificare eșuată, adaugă un mesaj de eroare și afișează din nou pagina de login
                    ModelState.AddModelError("", "Invalid email or password");
                    return View(model);
                }
            }

            // Dacă modelul nu este valid, afișează din nou pagina de login cu erorile corespunzătoare
            return View(model);
        }

        public IActionResult Register()
        {
            var model = new Utilizator();
            return View(model);
        }


        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
