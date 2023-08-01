using AutoMapper;
using FluentValidation;
using KiwiSuit.DTO;
using KiwiSuit.Models;
using KiwiSuit.Repositery;
using KiwiSuit.Data;

namespace KiwiSuit.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepositery _productRepository;



        public ProductService(IMapper mapper, IProductRepositery productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public void Create(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _productRepository.AddProductAsync(product);
        }

        public async Task Delete(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }

        public async Task<List<ProductDTO>> GetAllProductAsync()
        {
            var product = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<List<ProductDTO>>(product);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _productRepository.GetProducByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async void Update(int id, ProductDTO productDTO)
        {
            var product = await _productRepository.GetProducByIdAsync(id);
            if (product == null)
                return;

            _mapper.Map(productDTO, product);
            _productRepository.UpdateProductAsync(id, product);
        }
    }
}
