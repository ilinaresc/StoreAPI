using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreDOMAIN.Core.Entities;
using StoreDOMAIN.Core.Interfaces;
using StoreDOMAIN.Infrastructure.Data;



namespace StoreDOMAIN.Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly StoreDbContext _dbContext;
        public FavoriteRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Favorite>> GetAll()
        {
            return await _dbContext.Favorite.ToListAsync();
        }

        public async Task<Favorite> GetById(int id)
        {
            return await _dbContext
                    .Favorite
                    .Where(f => f.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Favorite favorite)
        {
            await _dbContext.Favorite.AddAsync(favorite);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findFavorite = await _dbContext
                .Favorite
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();

            if (findFavorite == null) return false;

            _dbContext.Favorite.Remove(findFavorite);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
