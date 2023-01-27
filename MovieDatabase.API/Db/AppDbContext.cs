using Microsoft.EntityFrameworkCore;
using MovieDatabase.API.Db.Entities;

namespace MovieDatabase.API.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<MovieEntity> Movies { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
