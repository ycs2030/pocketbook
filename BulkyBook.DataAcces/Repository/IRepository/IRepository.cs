using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAcces.Repository.IRepository
{
    // this for use on all class instesd of obj
    public interface IRepository<T> where T : class
    {
        // this use for find first or Default
        T GetFirstorDefault(Expression<Func<T,bool>>filter);
        //T - Category thius for use class 
        IEnumerable<T> GetAll();
        void Add(T entity); // for create
        void Remove(T entity); // delete
        void RemoveRange(IEnumerable<T> entity); // delete some of 
    }
}
