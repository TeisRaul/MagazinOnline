using Magazin_Online.Data;
using Magazin_Online.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Magazin_Online.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
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

        public IActionResult AddProduct() {
            return View();
        }
    }
}
