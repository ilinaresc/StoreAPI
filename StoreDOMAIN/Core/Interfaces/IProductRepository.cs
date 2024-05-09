using StoreDOMAIN.Core.Entities;

namespace StoreDOMAIN.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> Delete(int id);
        Task<bool> DeleteLogic(int id);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<bool> Insert(Product product);
        Task<bool> Update(Product product);
    }
}