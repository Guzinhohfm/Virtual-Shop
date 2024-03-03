using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductAPI.Models;

namespace VirtualShop.ProductAPI.Context;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
    
    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    //FLUENT API

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasKey(c => c.Id);

        modelBuilder.Entity<Category>().
            Property(c => c.Name).HasMaxLength(100).IsRequired();

        modelBuilder.Entity<Product>().
            Property(c => c.Name).HasMaxLength(100).IsRequired();

        modelBuilder.Entity<Product>().
            Property(c => c.Description).HasMaxLength(255).IsRequired();

        modelBuilder.Entity<Product>().
            Property(c => c.ImageURL).HasMaxLength(255).IsRequired();


        modelBuilder.Entity<Product>().
            Property(c => c.Price).HasPrecision(12, 2).IsRequired();

        modelBuilder.Entity<Category>()
            .HasMany(g => g.Products).
            WithOne(c => c.Category).
            IsRequired()
            .OnDelete(DeleteBehavior.Cascade);//Caso seja deletado uma categoria, todos os produtos relacionados irao junto


        modelBuilder.Entity<Category>()
            .HasData(
                new Category
                {
                    Id = 1,
                    Name = "Material Escolar",
                },
                new Category
                {
                    Id = 2,
                    Name = "Acessórios",
                }
            );

        //base.OnModelCreating(modelBuilder);
    }
}
