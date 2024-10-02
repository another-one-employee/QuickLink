using Microsoft.EntityFrameworkCore;
using QuickLink.Application.Models;

namespace QuickLink.Infrastructure.Data
{
    public class ShortLinksDbContext : DbContext
    {
        public DbSet<ShortLink> ShortLinks { get; set; }

        public ShortLinksDbContext(DbContextOptions<ShortLinksDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
