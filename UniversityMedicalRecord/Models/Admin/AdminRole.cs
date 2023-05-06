namespace UniversityMedicalRecord.Models.Admin;

public class AdminRole
{
    public int Id { get; set; }
    public Admin Admin { get; set; }
    public Position Position { get; set; }
}