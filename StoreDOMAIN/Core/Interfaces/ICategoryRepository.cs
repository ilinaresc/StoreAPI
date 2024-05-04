using StoreDOMAIN.Core.Entities;

namespace StoreDOMAIN.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> Delete(int id);
        Task<bool> DeleteLogic(int id);
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        string getName();
        Task<bool> Insert(Category category);
        Task<bool> Update(Category category);
    }
}