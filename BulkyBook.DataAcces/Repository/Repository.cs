using Microsoft.EntityFrameworkCore;
using BulkyBook.DataAcces.Repository.IRepository;
using System.Linq.Expressions;


namespace BulkyBook.DataAcces.Repository
{
    // the first thing do enter face and after do class to use enter face
    // this for generic
    public class Repository<T> : IRepository<T> where T : class
    {   // this to db context on it 
        private readonly ApplicationDbContext _db;
        // use class Db context
        internal DbSet<T> dbset; 
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>(); // impate class to use it 
        }
        //
        public void Add(T entity)
        {
           // _db.categories.Add(obj); //like this from class 
            dbset.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbset;
            return query.ToList();
        }

        public T GetFirstorDefault(Expression<Func<T, bool>> filter)
        {
            // this for get data by id name 
            IQueryable<T> query=dbset;
            query=query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbset.RemoveRange(entity);
        }
    }
}
