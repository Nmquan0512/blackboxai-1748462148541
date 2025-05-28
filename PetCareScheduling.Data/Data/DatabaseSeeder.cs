using PetCareScheduling.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace PetCareScheduling.Data.Data
{
    public class DatabaseSeeder
    {
        private readonly ApplicationDbContext _context;

        public DatabaseSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Only seed if the database is empty
            if (!await _context.Services.AnyAsync())
            {
                // Add Services
                var services = new List<Service>
                {
                    new Service
                    {
                        Name = "Basic Grooming",
                        Description = "Basic grooming service including bath, brush, and nail trim",
                        Price = 50.00m,
                        Duration = 60,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Service
                    {
                        Name = "Full Grooming",
                        Description = "Complete grooming service including bath, haircut, brush, and nail trim",
                        Price = 80.00m,
                        Duration = 90,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Service
                    {
                        Name = "Nail Trimming",
                        Description = "Professional nail trimming service",
                        Price = 20.00m,
                        Duration = 30,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    }
                };

                await _context.Services.AddRangeAsync(services);

                // Add Staff
                var staff = new List<Staff>
                {
                    new Staff
                    {
                        Name = "John Smith",
                        Email = "john.smith@petcare.com",
                        Phone = "123-456-7890",
                        Role = "Senior Groomer",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Staff
                    {
                        Name = "Jane Doe",
                        Email = "jane.doe@petcare.com",
                        Phone = "123-456-7891",
                        Role = "Groomer",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    }
                };

                await _context.Staff.AddRangeAsync(staff);

                // Add Sample Customers
                var customers = new List<Customer>
                {
                    new Customer
                    {
                        Name = "Alice Johnson",
                        Email = "alice.j@email.com",
                        Phone = "123-555-0101",
                        Address = "123 Pet Street",
                        CreatedAt = DateTime.UtcNow
                    },
                    new Customer
                    {
                        Name = "Bob Wilson",
                        Email = "bob.w@email.com",
                        Phone = "123-555-0102",
                        Address = "456 Animal Avenue",
                        CreatedAt = DateTime.UtcNow
                    }
                };

                await _context.Customers.AddRangeAsync(customers);

                // Save changes
                await _context.SaveChangesAsync();
            }
        }
    }
}
