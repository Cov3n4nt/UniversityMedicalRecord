namespace UniversityMedicalRecord.Models.User;

public class Subject
{
    public int Id { get; set; }
    public  User user { get; set; }
    public UserPosition UserPosition { get; set; }
}