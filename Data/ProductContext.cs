using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Data;

public class ProductContext : IdentityDbContext {

    public ProductContext(DbContextOptions<ProductContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        this.SeedProducts(builder);
    }

    public DbSet<Product> Products {get;set;}

    public DbSet<Product> Product { get; set; }

    private void SeedProducts(ModelBuilder builder){
        builder.Entity<Product>().HasData();
    }
}