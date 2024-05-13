using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class StyleController : Controller
{
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ChangeColors(string backgroundColor, string fontFamily)
    {
        Debug.WriteLine("Culoare de fundal: " + backgroundColor);
        Debug.WriteLine("Font: " + fontFamily);

        HttpContext.Session.SetString("BackgroundColor", backgroundColor);
        HttpContext.Session.SetString("FontFamily", fontFamily);

        var background = HttpContext.Session.GetString("BackgroundColor");
        var font = HttpContext.Session.GetString("FontFamily");
        Debug.WriteLine("Culoare de fundal setată în sesiune: " + background);
        Debug.WriteLine("Font setat în sesiune: " + font);

        return Redirect(Request.Headers["Referer"].ToString());
    }

}
