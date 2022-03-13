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
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        // this injection db context
        private ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
      
                
        public void update(CoverType obj)
        {
            // this for the name of Dbset CoverType this and was CoverTypes
            _db.CoverTypes.Update(obj);
        }
        
    }
}
