﻿namespace UniversityMedicalRecord.Models.User;

public class Employee
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string? Middlename { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}