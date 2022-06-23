using Microsoft.EntityFrameworkCore;
using SharpScape.Api.Models;
using SharpScape.Api.Data.Models;

namespace SharpScape.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<SharpScape.Api.Models.Thread> Threads { get; set; }
    public DbSet<SharpScape.Api.Data.Models.Commentor> Commentor { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Commentor>(x =>
        {
            x.HasData(
                new Commentor() { Id = 1, Name = "Bob", Comment = "Testing out db 1" },
                new Commentor() { Id = 2, Name = "John", Comment = "Testing out db 2" },
                new Commentor() { Id = 3, Name = "Sandra", Comment = "Testing out db 3" }
                );
        });
    }
}