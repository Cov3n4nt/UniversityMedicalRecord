namespace UniversityMedicalRecord.Models.User;

public class User
{
    public int Id { get; set; }
    public  Employee Employee { get; set; }
    public UserPosition UserPosition { get; set; }
}