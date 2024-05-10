using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Magazin_Online.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Magazin_Online.Data;
using Magazin_Online.Data.Enums;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
                        RedirectUri = "/Home/Product"
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Index", "Product");
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
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var newUser = new Utilizator
            {
                Nume = registerVM.Nume,
                Prenume = registerVM.Prenume,
                Email = registerVM.Email,
                Parola = registerVM.Parola,
                Adresa = registerVM.Adresa,
                Oras = registerVM.Oras,
                Telefon = registerVM.Telefon,
                AdminId = 1
            };

            _context.Utilizator.Add(newUser);

            await _context.SaveChangesAsync();

            return RedirectToAction("RegisterCompleted");
        }

        public IActionResult RegisterCompleted()
        {
            return View();
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

        [HttpGet]
        public async Task<IActionResult> Edit()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Utilizator model)
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
            if (User.Identity.IsAuthenticated)
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrEmpty(userId))
                {
                    var user = _context.Utilizator.FirstOrDefault(u => u.Id.ToString() == userId);

                    if (user != null)
                    {
                        user.Nume = model.Nume;
                        user.Prenume = model.Prenume;
                        user.Email = model.Email;
                        user.Adresa = model.Adresa;
                        user.Oras = model.Oras;
                        user.Telefon = model.Telefon;

                        _context.Update(user);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("Profile");
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            return View("Profile");
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
    }
}
