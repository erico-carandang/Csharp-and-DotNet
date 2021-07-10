using Microsoft.EntityFrameworkCore;
namespace Packt.Shared
{
    // this manages the connection to the database
    public class Northwind: DbContext
    {
        // these properties map to tables in the database
        public DbSet<Categories> Categories { get; set; }     
        public DbSet<Products> Products { get; set; }    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)    
        {      
            string path = System.IO.Path.Combine(
                System.Environment.CurrentDirectory, "Northwind.db");      
            optionsBuilder.UseSqlite($"Filename={path}");    
        }
        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            // example of using Fluent API instead of attributes      
            // to limit the length of a category name to 15
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryID);

                entity.HasIndex(e => e.CategoryName)
                    .HasName("CategoryName");

                entity.Property(e => e.CategoryID).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Description).HasColumnType("ntext");

              
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductID);

                entity.HasIndex(e => e.CategoryID, "CategoriesProducts");

                entity.HasIndex(e => e.CategoryID, "CategoryID");

                entity.HasIndex(e => e.ProductName, "ProductName");

                entity.Property(e => e.ProductID).HasColumnName("ProductID");

                entity.Property(e => e.CategoryID).HasColumnName("CategoryID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);

                
                    
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryID)
                    .HasConstraintName("FK_Products_Categories");

               
            });

        }
    }
}
