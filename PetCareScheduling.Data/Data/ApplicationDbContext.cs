using Microsoft.EntityFrameworkCore;
using PetCareScheduling.Data.Entities;

namespace PetCareScheduling.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentService> AppointmentServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Staff)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppointmentService>()
                .HasOne(a => a.Appointment)
                .WithMany(a => a.AppointmentServices)
                .HasForeignKey(a => a.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppointmentService>()
                .HasOne(a => a.Service)
                .WithMany(s => s.AppointmentServices)
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure decimal columns for SQLite
            modelBuilder.Entity<Appointment>()
                .Property(a => a.TotalAmount)
                .HasConversion<double>();

            modelBuilder.Entity<AppointmentService>()
                .Property(a => a.Price)
                .HasConversion<double>();

            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasConversion<double>();

            // Configure default values for SQLite
            modelBuilder.Entity<Customer>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("datetime('now')");

            modelBuilder.Entity<Service>()
                .Property(s => s.CreatedAt)
                .HasDefaultValueSql("datetime('now')");

            modelBuilder.Entity<Staff>()
                .Property(s => s.CreatedAt)
                .HasDefaultValueSql("datetime('now')");

            modelBuilder.Entity<Appointment>()
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("datetime('now')");

            modelBuilder.Entity<AppointmentService>()
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("datetime('now')");
        }
    }
}
