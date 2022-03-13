using System;
using BulkyBook.DataAcces.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkyBook.Model;

namespace BulkyBook.DataAcces.Repository
{
    // the first thing do enter face and after do class to use enter face
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        // this injection db context
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
      
                
        public void update(Category obj)
        {
           _db.categories.Update(obj);
        }
    }
}
