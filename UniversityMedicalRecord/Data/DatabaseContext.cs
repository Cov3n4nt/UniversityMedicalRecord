using Microsoft.EntityFrameworkCore;
using UniversityMedicalRecord.Models;
using UniversityMedicalRecord.Models.Admin;
using UniversityMedicalRecord.Models.User;

namespace UniversityMedicalRecord.Data;

public class DatabaseContext: DbContext
{
    public const string CONNECTION_STRING =
        @"Server=(localdb)\mssqllocaldb;Database=UniversityMedicalRecord;Trusted_Connection=True";
    
   
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
    
    public DbSet<Admin> Admins { get; set; }
    public DbSet<AdminRole> AdminRoles { get; set; }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<User> Users { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(CONNECTION_STRING);
    }
    
    public List<GenericUser> GetUsers()
    {
        var users = Admins.Select(x => x as GenericUser).ToList();
        var employees = Employees.Select(x => x as GenericUser).ToList();
        users.AddRange(employees);
        return users;
    }
    
    
}