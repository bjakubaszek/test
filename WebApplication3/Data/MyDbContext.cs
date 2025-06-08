using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data;

public class MyDbContext : DbContext
{
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Course> Courses { get; set; }
    
    public MyDbContext(DbContextOptions options) : base(options)
    {
    }
}