using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;

namespace UniversityMedicalRecord.Pages.Homepage;

[Authorize]
public class IndexModel : PageModel
{
    private readonly DatabaseContext _context;

    public IndexModel(DatabaseContext context)
    {
        _context = context;
    }
    
    [BindProperty]
    public string Name { get; set;}

    public void OnGet()
    {
        var userId = HttpContext.Session.GetInt32(Session.UserIdKey);
        if (userId == null) return;
        var user = _context.GetUser((int)userId);
        if (user == null) return;
        Name = user.Firstname;
        
    }
    public async Task<IActionResult> OnPostAsync()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
        
        HttpContext.Session.SetInt32(Session.UserIdKey, -1);

        return RedirectToPage("../Index");
    }

}
