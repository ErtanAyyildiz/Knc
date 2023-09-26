using Knc.Entity.Modals;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knc.DataAccess.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);


        //    modelBuilder.Entity<Category>()
        //     .HasKey(c => c.Id);

        //    modelBuilder.Entity<SubCategory>()
        //        .HasKey(sc => sc.Name); // Varsayılan olarak string tipi birincil anahtar

        //    modelBuilder.Entity<Product>()
        //        .HasKey(p => p.Id);

        //    // Category ile SubCategory arasındaki ilişkiyi tanımla
        //    modelBuilder.Entity<Category>()
        //        .HasMany(c => c.SubCategories)
        //        .WithOne(sc => sc.Category)
        //        .HasForeignKey(sc => sc.CategoryId);

        //    // SubCategory ile Product arasındaki ilişkiyi tanımla
        //    modelBuilder.Entity<SubCategory>()
        //        .HasMany(sc => sc.Products)
        //        .WithOne(p => p.SubCategory)
        //        .HasForeignKey(p => p.SubCategoryId);
        //}
    }
}
