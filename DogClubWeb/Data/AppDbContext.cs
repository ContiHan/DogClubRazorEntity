using DogClubWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace DogClubWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Dog>? Dogs { get; set; }
    }
}
