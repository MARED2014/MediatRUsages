using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace PersistanceLayer.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Holiday> Holidays { get; set; } 
}
