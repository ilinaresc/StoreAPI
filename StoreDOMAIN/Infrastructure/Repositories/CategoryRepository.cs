using Microsoft.EntityFrameworkCore;
using StoreDOMAIN.Core.Entities;
using StoreDOMAIN.Core.Interfaces;
using StoreDOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace StoreDOMAIN.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string getName()
        {
            return "Irving";
        }

        // Sincrono
        //public IEnumerable<Category> GetAll()
        //{
        //    var categories = _dbContext
        //        .Category
        //        .Where(c => c.IsActive == true)
        //        .ToList();
        //    return categories;
        //}

        // Asincrono -> peticiones a nivel de API
        // se ejecuta en simultaneo
        // mejora los tiempos de respuesta
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext
                .Category
                .Where(c => c.IsActive == true)
                .ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _dbContext
                .Category
                .Where(c => c.IsActive == true && c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Category category)
        {
            await _dbContext.Category.AddAsync(category);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Category category)
        {
            _dbContext.Category.Update(category);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findCategory = await _dbContext
                .Category
                .Where(x => x.IsActive == true && x.Id == id)
                .FirstOrDefaultAsync();

            if (findCategory == null) return false;

            _dbContext.Category.Remove(findCategory);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteLogic(int id)
        {
            var findCategory = await _dbContext
                .Category
                .Where(x => x.IsActive == true && x.Id == id)
                .FirstOrDefaultAsync();

            if (findCategory == null) return false;

            findCategory.IsActive = false;
            int rows = await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
