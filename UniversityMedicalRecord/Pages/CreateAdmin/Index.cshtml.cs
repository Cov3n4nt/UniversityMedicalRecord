using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models.Admin;

namespace UniversityMedicalRecord.Pages.CreateAdmin;

public class IndexModel : PageModel
{
    private readonly DatabaseContext _context;

    public IndexModel(DatabaseContext context)
    {
        _context = context;
    }
    
    [BindProperty]
    [Display(Name = "First name")]
    public string FirstName { get; set; }
    
    [BindProperty]
    [Display(Name = "Middle name")]
    public string? MiddleName { get; set; }
    
    [BindProperty]
    [Display(Name = "Last name")]
    public string LastName { get; set; }
    
    [BindProperty]
    [Display(Name = "Username")]
    public string Username { get; set; }
    
    [BindProperty]
    [Display(Name = "Password")]
    public string Password { get; set; }
    public async Task<IActionResult> OnPostAsync()
    {
        var isUsernameDuplicate = _context.GetUsers().Any(x => x.Username == Username);
        
        if (!ModelState.IsValid || isUsernameDuplicate)
        {
            return Page();
        }

        var passwordSalt = Hash.GenerateSalt();
        var passwordHash = Password.ComputeHash(passwordSalt);
        
        var admin = new Admin
        {
            Firstname = FirstName,
            Middlename = MiddleName,
            Lastname = LastName,
            Username = Username,
            PasswordHash = passwordHash,
            PasswordSalt = Convert.ToBase64String(passwordSalt)
        };
        
        _context.Admins.Add(admin);

        var superAdminRole = new AdminRole
        {
            Admin = admin,
            Position = Position.SuperAdmin
        };
        
        _context.AdminRoles.Add(superAdminRole);
        
        await _context.SaveChangesAsync();
        
        return RedirectToPage("./Index");
    }
    
}