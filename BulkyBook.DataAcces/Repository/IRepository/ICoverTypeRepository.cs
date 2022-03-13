﻿using System;
using BulkyBook.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAcces.Repository.IRepository
{
    // this for use model
    public interface IProductRepository : IRepository<Product>
    {
        // this for edit item 
        void update(Product obj);
      
    }
}
