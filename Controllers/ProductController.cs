using Magazin_Online.Data;
using Magazin_Online.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

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

        public async Task<IActionResult> Index()
        {
            var data = await _context.Produs.Include(n => n.Utilizator).OrderBy(n => n.Denumire).ToListAsync();
            return View(data);
        }

        public IActionResult Detail(int id)
        {
            return View();
        }

        public async Task<IActionResult> AddProduct(List<IFormFile> files, Produs produs)
        {
            if (!ModelState.IsValid)
            {
                return View(produs);
            }

            var fileNames = new List<string>();
            if (files != null && files.Count > 0)
            {
                var uploads = Path.Combine(_hostEnvironment.WebRootPath, "uploads");
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(uploads, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        fileNames.Add(fileName); // Adăugăm numele fișierului la lista de nume
                    }
                }
            }

            // Atribuim primul nume de fișier, dacă există
            var imagine = fileNames.FirstOrDefault();

            var newProduct = new Produs
            {
                Denumire = produs.Denumire,
                Categorie = produs.Categorie,
                Pret = produs.Pret,
                Descriere = produs.Descriere,
                Nr_buc = produs.Nr_buc,
                Localitate = produs.Localitate,
                Imagine = imagine // Atribuim imaginea
            };

            _context.Produs.Add(newProduct);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyProducts");
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

        // Acțiune pentru a edita un produs
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
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

        private bool ProductExists(int id)
        {
            return _context.Produs.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Denumire,Categorie,Pret,Imagine,Descriere,Nr_buc,Localitate")] Produs product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MyProducts));
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Produs.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Produs.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MyProducts));
        }
    }
}
