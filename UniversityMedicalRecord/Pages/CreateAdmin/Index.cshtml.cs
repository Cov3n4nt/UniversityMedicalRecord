using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityMedicalRecord.Data;
using UniversityMedicalRecord.Models;
using UniversityMedicalRecord.Models.Admin;
using UniversityMedicalRecord.Models.User;

namespace UniversityMedicalRecord.Pages.CreateAdmin;

public class IndexModel : PageModel
{
    private readonly DatabaseContext _context;

    public IndexModel(DatabaseContext context)
    {
        _context = context;
    } 
    public bool HasSuperAdmin { get; set; }
    public string PageTitle { get; set; }
    [BindProperty] public string UserType { get; set; }

    
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
    
    public void OnGetAsync()
    {
        HasSuperAdmin = _context.HasSuperAdmin();
        PageTitle = !HasSuperAdmin ? "Create admin" : "Create user";
    }
    public async Task<IActionResult> OnPostAsync()
    {
        var isUsernameDuplicate = _context.GetUsers().Any(x => x.Username == Username);
        
        if (!ModelState.IsValid||isUsernameDuplicate)
        {
            return Page();
        }
      
        var passwordSalt = Hash.GenerateSalt();
        var passwordHash = Password.ComputeHash(passwordSalt);

        var user = UserType == "admin" || !HasSuperAdmin
            ? new Admin()
            {
                Firstname = FirstName,
                Middlename = MiddleName,
                Lastname = LastName,
                Username = Username,
                PasswordHash = passwordHash,
                PasswordSalt = Convert.ToBase64String(passwordSalt)
            }
            : new Employee()
            {
                Firstname = FirstName,
                Middlename = MiddleName,
                Lastname = LastName,
                Username = Username,
                PasswordHash = passwordHash,
                PasswordSalt = Convert.ToBase64String(passwordSalt)
            } as GenericUser;
        
        _context.AddUser(user);

        if (!HasSuperAdmin)
        {
            var superAdminRole = new AdminRole
            {
                Admin = (user as Admin)!,
                Position = Position.SuperAdmin
            };
        
            _context.AdminRoles.Add(superAdminRole);  
        }
        
        
        await _context.SaveChangesAsync();
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(Data.Login.GetClaimIdentity(user)),
            Data.Login.AuthProperties);

        HttpContext.Session.SetInt32(Session.UserIdKey, user.Id);
        return RedirectToPage("../Login/Index");
    }
    
    
    
}