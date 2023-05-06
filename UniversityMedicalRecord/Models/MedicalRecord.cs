using UniversityMedicalRecord.Models.User;

namespace UniversityMedicalRecord.Models;

public enum Gender
{
    Male,
    Female
}

public class MedicalRecord
{
    public Subject Subject { get; set;}
    public string Age { get; set; }
    public Gender Gender { get; set; } 
    public DateOnly DateOfBirth { get; set; } 
    public string Address { get; set; } 
    // ???
}