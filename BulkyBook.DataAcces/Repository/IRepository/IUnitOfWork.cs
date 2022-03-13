using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAcces.Repository.IRepository
{
    public interface IUnitOfWork
    {
        // this fore get the table class category  to put in categoryRepository  
        ICategoryRepository Category { get; }
        // this fore get the table class CoverType  to put in CavorTypeRepository
        ICoverTypeRepository CoverType { get; }
        // this fore get the table class product  to put in productRepository
        IProductRepository product { get; }
        void save();
    }
}
