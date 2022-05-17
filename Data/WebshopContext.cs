using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data 
{
    public class WebshopContext : IdentityDbContext {

        public WebshopContext(DbContextOptions<WebshopContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedProducts(builder);
        }

        public DbSet<Product> Products { get; set; }

        private void SeedProducts(ModelBuilder builder)
        {
                builder.Entity<Product>().HasData(
                    new Product("Gibson Les Paul Standard", "This is a guitar",15000,1)
                );
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        private void SeedUsers(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User("Jens","I am Jens",1)
            );
        }
    }
}