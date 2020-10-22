using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using skolu_nepobiram.Database.Models;

namespace skolu_nepobiram.Database
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DbSet<SchoolModel> Schools { get; set; }
        public DbSet<CovidInfection> ProvinceInfections { get; set; }

        public DbSet<SkatePlace> SkatePlaces { get; set; }
        public DbSet<KnownPlace> KnownPlaces { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> o) : base(o)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SkatePlace>().HasMany(p => p.Liked);
            builder.Entity<ApplicationUser>().HasMany(u => u.Places);

            base.OnModelCreating(builder);
        }
    }
}