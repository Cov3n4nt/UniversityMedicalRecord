using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using UniversityMedicalRecord.Models;
using UniversityMedicalRecord.Models.User;

namespace UniversityMedicalRecord.Data;

public class Login
{
    public static readonly AuthenticationProperties AuthProperties = new AuthenticationProperties
    {
        AllowRefresh = true,
        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1440),
        IsPersistent = true,
        IssuedUtc = DateTimeOffset.UtcNow
    };

    public static ClaimsIdentity GetClaimIdentity(GenericUser user)
    {
        var claims = new List<Claim>()
        {
            new("UserId", user.Id.ToString())
        };

        return new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);
    }
}