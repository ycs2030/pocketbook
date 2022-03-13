using BulkyBook.DataAcces.Data;
using BulkyBook.Model;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAcces
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        // this for create table Catagory to data basa SQL
        public DbSet<Category> categories { get; set; }
        // this for create table CoverType to data basa SQL
        public DbSet<CoverType> CoverTypes { get; set; }
        // this for create Product to data basa SQL
        public DbSet<Product> products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ModelBuliderConfiguration();
            base.OnModelCreating(modelBuilder);
        }

    }

    
}
