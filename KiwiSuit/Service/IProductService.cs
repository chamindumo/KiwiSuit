using KiwiSuit.DTO;
using KiwiSuit.Models;

namespace KiwiSuit.Service
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProductAsync();
        void Create(ProductDTO productDTO);
        void Update(int id, ProductDTO productDTO);
        Task Delete(int id);
        Task<ProductDTO> GetProductById(int id);

    }
}
