using Magazin_Online.Data;
using Magazin_Online.Data.ViewModels;
using Magazin_Online.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Web;

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


        public IActionResult Detail(int id)
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

        //public ActionResult SaveUploadedFile()
        //{
        //    bool isSavedSuccessfully = true;
        //    string fName = "";
        //    try
        //    {
        //        foreach (string fileName in Request.Files)
        //        {
        //            HttpPostedFileBase file = Request.Files[fileName];
        //            //Save file content goes here
        //            fName = Guid.NewGuid().ToString(); //file.FileName;
        //            if (file != null && file.ContentLength > 0)
        //            {

        //                var originalDirectory = new System.IO.DirectoryInfo(string.Format("{0}Images\\uploaded", Server.MapPath(@"\")));
        //                string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");
        //                var fileName1 = System.IO.Path.GetFileName(file.FileName);
        //                bool isExists = System.IO.Directory.Exists(pathString);
        //                if (!isExists)
        //                    System.IO.Directory.CreateDirectory(pathString);
        //                var path = string.Format("{0}\\{1}", pathString, fName);
        //                file.SaveAs(path);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        isSavedSuccessfully = false;
        //    }

        //    if (isSavedSuccessfully)
        //        return Json(new { Message = fName });
        //    else
        //        return Json(new { Message = "Error in saving file" });
        //}

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Denumire,Categorie,Pret,Imagine,Descriere,Nr_buc,Localitate")] Produs produs)
        {
            if (id != produs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produs);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["UtilizatorId"] = new SelectList(_context.Utilizator, "Id", "Email", produs.UtilizatorId);
            return View(produs);
        }

        // GET: Produs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produs = await _context.Produs
                .Include(p => p.Admin)
                .Include(p => p.Utilizator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produs == null)
            {
                return NotFound();
            }

            return View(produs);
        }

        // POST: Produs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produs = await _context.Produs.FindAsync(id);
            if (produs != null)
            {
                _context.Produs.Remove(produs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdusExists(int id)
        {
            return _context.Produs.Any(e => e.Id == id);
        }
    }
}
