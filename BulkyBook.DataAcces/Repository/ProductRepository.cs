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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        // this injection db context
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
      
                
        public void update(Product obj)
        {
            // this for the name of Dbset Product this and was Product
           // _db.products.Update(obj);

            //this for  other way to if you update product name
            var objFromDb = _db.products.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb == null)
            {
                objFromDb.Title =obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Author = obj.Author;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.CoverTypeId = obj.CoverTypeId;
                if(obj.ImageUrl !=null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
                
            }
        }
    }
}
