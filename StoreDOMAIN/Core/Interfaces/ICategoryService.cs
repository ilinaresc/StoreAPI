using StoreDOMAIN.Core.DTO;

namespace StoreDOMAIN.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListDTO>> GetAll();
        Task<IEnumerable<CategoryProductsDTO>> GetWithProduts();
        Task<CategoryListDTO> GetById(int id);
        Task<CategoryProductsDTO> GetByIdWithProducts(int id);
        Task<bool> Create(CategoryCreateDTO categoryCreate);
    }
}