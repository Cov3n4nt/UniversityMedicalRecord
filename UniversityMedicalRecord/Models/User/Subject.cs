namespace UniversityMedicalRecord.Models.User;

public class Subject
{
    public int Id { get; set; }
    public Student Student { get; set; }
    public College College { get; set; }
}