using Microsoft.AspNetCore.Mvc;
using Magazin_Online.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Magazin_Online.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Magazin_Online.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Account/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Utilizator.FirstOrDefaultAsync(u => u.Email == email && u.Parola == password);

                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, $"{user.Nume} {user.Prenume}"),
                        new Claim(ClaimTypes.Email, user.Email),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        RedirectUri = "/Home/Index"
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password");
                }
            }

            return View();
        }



        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Utilizator model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingUser = _context.Utilizator.FirstOrDefault(u => u.Email == model.Email);
                    if (existingUser != null)
                    {
                        ModelState.AddModelError(string.Empty, "Adresa de email este deja înregistrată.");
                        return View(model);
                    }

                    _context.Utilizator.Add(model);
                    _context.SaveChanges();

                    // Afișează un mesaj de depanare în consolă
                    Console.WriteLine("Utilizatorul a fost înregistrat cu succes!");

                    return RedirectToAction("Login", "Account");
                }
                catch (Exception ex)
                {
                    // Afișează un mesaj de depanare în consolă
                    Console.WriteLine("Eroare la salvarea utilizatorului: " + ex.Message);

                    ModelState.AddModelError(string.Empty, "Eroare: " + ex.Message);
                    return View(model);
                }
            }

            // Afișează un mesaj de depanare în consolă
            Console.WriteLine("Datele utilizatorului nu sunt valide.");

            return View(model);
        }





        // GET: Account/Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        // GET: Account/Profile
        public IActionResult Profile()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (!string.IsNullOrEmpty(userId))
                {
                    var user = _context.Utilizator.FirstOrDefault(u => u.Id.ToString() == userId);

                    if (user != null)
                    {
                        return View(user);
                    }
                }
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Utilizator model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingUser = await _context.Utilizator.FindAsync(model.Id);

                    if (existingUser != null)
                    {
                        existingUser.Nume = model.Nume;
                        existingUser.Prenume = model.Prenume;
                        existingUser.Email = model.Email;
                        existingUser.Adresa = model.Adresa;
                        existingUser.Oras = model.Oras;
                        existingUser.Telefon = model.Telefon;

                        _context.Update(existingUser);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("Profile");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
            }

            return View("Profile", model);
        }



        // POST: Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (!string.IsNullOrEmpty(userId))
                {
                    var user = await _context.Utilizator.FindAsync(int.Parse(userId));

                    if (user != null)
                    {
                        if (user.Parola == currentPassword)
                        {
                            if (newPassword == confirmPassword)
                            {
                                user.Parola = newPassword;
                                _context.Update(user);
                                await _context.SaveChangesAsync();

                                return RedirectToAction("Profile");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Parolele noi nu se potrivesc.");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Parola curentă este incorectă.");
                        }
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }

            return View();
        }
        // POST: Account/LogoutOnClose
        [HttpPost]
        public IActionResult LogoutOnClose()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            HttpContext.Session.Remove("UserId");
            return Ok();
        }

        // GET: Account/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
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
        // GET: Account/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
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