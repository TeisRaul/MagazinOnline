using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class StyleController : Controller
{
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ChangeColors(string backgroundColor, string fontFamily)
    {
        HttpContext.Session.SetString("BackgroundColor", backgroundColor);
        HttpContext.Session.SetString("FontFamily", fontFamily);
        return Redirect(Request.Headers["Referer"].ToString());
    }
}
