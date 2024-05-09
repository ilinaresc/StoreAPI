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
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext
                .Product
                .Where(p => p.IsActive == true)
                .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _dbContext
                .Product
                .Where(p => p.IsActive == true && p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Product product)
        {
            await _dbContext.Product.AddAsync(product);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Product product)
        {
            _dbContext.Product.Update(product);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findProduct = await _dbContext
                .Product
                .Where(p => p.IsActive == true && p.Id == id)
                .FirstOrDefaultAsync();

            if (findProduct == null) return true;

            _dbContext.Product.Remove(findProduct);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteLogic(int id)
        {
            var findProduct = await _dbContext
                .Product
                .Where(p => p.IsActive == true && p.Id == id)
                .FirstOrDefaultAsync();

            if (findProduct == null) return true;

            findProduct.IsActive = false;
            int rows = await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
