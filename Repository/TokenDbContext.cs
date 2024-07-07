using Microsoft.EntityFrameworkCore;
using SallaIntegration.Repository.Models;
using System.Collections.Generic;

namespace SallaIntegration.Repository
{
    public class TokenDbContext : DbContext
    {
        public TokenDbContext(DbContextOptions<TokenDbContext> options) : base(options)
        {
        }


        public DbSet<AccessToken> AccessTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessToken>()
                .HasKey(a => a.Id); // Define 'Id' as the primary key

            // Optionally configure other properties or relationships here

            base.OnModelCreating(modelBuilder);
        }

    }
}
