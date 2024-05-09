using Microsoft.AspNetCore.Mvc;
using Magazin_Online.Models;
using Magazin_Online.Data;

public class ProductController : Controller
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult AddProduct()
    {
        var userId = User.Identity.Name;

        if (!string.IsNullOrEmpty(userId))
        {
            return View();
        }
        else
        {
            return RedirectToAction("Login", "Account");
        }
    }


}
