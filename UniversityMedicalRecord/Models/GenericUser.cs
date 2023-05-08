namespace UniversityMedicalRecord.Models;

public abstract class GenericUser 
{
    public abstract int Id { get; set; }
    public abstract string Firstname { get; set; }
    public abstract string? Middlename { get; set; }
    public abstract string Lastname { get; set; }
    public abstract string Username { get; set; }
    public abstract string Password { get; set; }
    public abstract string Email { get; set; }
    public abstract string PasswordHash { get; set; }
    public abstract string PasswordSalt { get; set; }
}
