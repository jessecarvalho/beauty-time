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
    public DbSet<Service> Services { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<WorkingDay> WorkingDays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>()
            .HasOne(e => e.Establishment);
        modelBuilder.Entity<Appointment>()
            .HasOne<User>(u => u.User);
        modelBuilder.Entity<Establishment>()
            .HasMany(e => e.Services)
            .WithOne(s => s.Establishment)
            .HasForeignKey(s => s.EstablishmentId);
        modelBuilder.Entity<Establishment>()
            .HasOne<User>(u => u.User);
    }
}