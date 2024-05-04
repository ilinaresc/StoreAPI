using Microsoft.EntityFrameworkCore;
using StoreDOMAIN.Core.Entities;
using StoreDOMAIN.Core.Interfaces;
using StoreDOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDOMAIN.Infrastructure.Repositories
{
    internal class ProductRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
