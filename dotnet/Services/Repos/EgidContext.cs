using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Repos;

public class EgidContext : DbContext
{
    public DbSet<Stock>? Stocks { get; set; }
    public DbSet<Order>? Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("egid");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Stock>()
            .HasKey(e => e.Id);
    }
}