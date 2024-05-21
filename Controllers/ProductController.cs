using Magazin_Online.Data;
using Magazin_Online.Data.ViewModels;
using Magazin_Online.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;


namespace Magazin_Online.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParam"] = System.String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var produse = _context.Produs
                .Include(p => p.Utilizator)
                .AsQueryable();

            if (!System.String.IsNullOrEmpty(searchString))
            {
                produse = produse.Where(p => p.Denumire.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_asc":
                    produse = produse.OrderBy(p => p.Denumire);
                    break;
                case "name_desc":
                    produse = produse.OrderByDescending(p => p.Denumire);
                    break;
                case "price_asc":
                    produse = produse.OrderBy(p => p.Pret);
                    break;
                case "price_desc":
                    produse = produse.OrderByDescending(p => p.Pret);
                    break;
                default:
                    produse = produse.OrderBy(p => p.Denumire);
                    break;
            }

            return View(await produse.AsNoTracking().ToListAsync());
        }


        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(ProdusVM produsVM)
        {
            if (produsVM.ImageFile == null || produsVM.ImageFile.Length == 0)
            {
                ModelState.AddModelError("", "Trebuie să încărcați o imagine.");
                return View(produsVM);
            }

            if (!produsVM.ImageFile.ContentType.ToLower().StartsWith("image/"))
            {
                ModelState.AddModelError("", "Fișierul trebuie să fie o imagine.");
                return View(produsVM);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(produsVM.ImageFile.FileName);
            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "uploads", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await produsVM.ImageFile.CopyToAsync(fileStream);
            }

            produsVM.Imagine = "/uploads/" + fileName;

            var produs = new Produs
            {
                Denumire = produsVM.Denumire,
                Categorie = produsVM.Categorie,
                Pret = produsVM.Pret,
                Descriere = produsVM.Descriere,
                Nr_buc = produsVM.Nr_buc,
                Localitate = produsVM.Localitate,
                Imagine = produsVM.Imagine,
                AdminId = 1,
                UtilizatorId = int.Parse(GetUserIdFromHttpContext())
            };

            _context.Add(produs);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private string GetUserIdFromHttpContext()
        {
            var userIdClaim = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userIdClaim;
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Produs.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> MyProducts()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return NotFound();
            }

            if (!int.TryParse(userId, out int userIdInt))
            {
                return NotFound();
            }

            var myProducts = await _context.Produs
                .Where(p => p.UtilizatorId == userIdInt)
                .ToListAsync();

            return View(myProducts);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return View("Error");
            }

            var produs = await _context.Produs.FirstOrDefaultAsync(p => p.UtilizatorId == int.Parse(userId));
            if (produs == null)
            {
                return NotFound();
            }

            var editVM = new ProdusVM
            {
                Denumire = produs.Denumire,
                Categorie = produs.Categorie,
                Pret = produs.Pret,
                Descriere = produs.Descriere,
                Nr_buc = produs.Nr_buc,
                Localitate = produs.Localitate,
            };

            return View(editVM);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdusVM produsVM)
        {
            if (id != produsVM.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", produsVM);
            }

            var produs = await _context.Produs.FindAsync(id);
            if (produs == null)
            {
                return NotFound();
            }

            produs.Denumire = produsVM.Denumire;
            produs.Categorie = produsVM.Categorie;
            produs.Pret = produsVM.Pret;
            produs.Descriere = produsVM.Descriere;
            produs.Nr_buc = produsVM.Nr_buc;
            produs.Localitate = produsVM.Localitate;

            try
            {
                _context.Update(produs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdusExists(produs.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ProdusExists(int id)
        {
            return _context.Produs.Any(e => e.Id == id);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var produs = await _context.Produs.FindAsync(id);
            if (produs == null)
            {
                return NotFound();
            }

            _context.Produs.Remove(produs);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyProducts));
        }
    }
}
