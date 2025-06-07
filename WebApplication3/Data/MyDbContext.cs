using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data;

public class MyDbContext : DbContext
{
    
    public DbSet<Partia> Partie { get; set; }
    public DbSet<Polityk> Politycy { get; set; }
    public DbSet<Przynaleznosc> Przynaleznoscsi { get; set; }
    
    public MyDbContext(DbContextOptions options) : base(options)
    {
    }
}