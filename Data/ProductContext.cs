using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Webshop.Data;

public class ProductContext : DbContext {

    public ProductContext(DbContextOptions<ProductContext> options) : base(options) {}

    public DbSet<Product> Product {get;set;}
}