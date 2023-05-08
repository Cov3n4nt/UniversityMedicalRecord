namespace UniversityMedicalRecord.Models.User;

public class Employee : GenericUser
{
    public override int Id { get; set; }
    public override string Firstname { get; set; }
    public override string? Middlename { get; set; }
    public override string Lastname { get; set; }
    public override string Username { get; set; }
    public override string Password { get; set; }
    public override string Email { get; set; }
    public override string PasswordHash { get; set; }
    public override string PasswordSalt { get; set; }
}