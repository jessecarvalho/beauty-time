using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Establishment> Establishments { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .HasMany(c => c.Appointments)
            .WithOne(a => a.Client)
            .HasForeignKey(a => a.ClientId);
        modelBuilder.Entity<Client>()
            .HasMany(c => c.Establishments)
            .WithMany(e => e.Clients);
        modelBuilder.Entity<Establishment>()
            .HasMany(e => e.Appointments)
            .WithOne(a => a.Establishment)
            .HasForeignKey(a => a.EstablishmentId);
        modelBuilder.Entity<Establishment>()
            .HasMany(e => e.Services)
            .WithOne(s => s.Establishment)
            .HasForeignKey(s => s.EstablishmentId);
    }
}