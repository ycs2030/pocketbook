using BulkyBook.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAcces.Data
{
    public static class SharedExtension
    {
        public static void ModelBuliderConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany
                (s => s.Products).WithOne(x => x.Category)
                .HasForeignKey(key => key.CategoryId);
        }
    }
}
