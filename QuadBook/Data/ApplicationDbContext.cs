using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuadBook.Models;

namespace QuadBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<QuadBook.Models.Location> Location { get; set; }
        public DbSet<QuadBook.Models.ResourceType> ResourceType { get; set; }
        public DbSet<QuadBook.Models.Resource> Resource { get; set; }
        public DbSet<QuadBook.Models.Booking> Booking { get; set; }
    }
}