using Finanblue.Application.Interfaces;
using Finanblue.Domain.Entities;
using Finanblue.Domain.Interfaces;

namespace Finanblue.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        public async Task<bool> Add(Product product)
        {
            try
            {
                if(product != null)
                {
                    return await _productRepository.Add(product);
                }
                else
                {
                    throw new Exception("Produto vazio");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                
             return _productRepository.Delete(id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Product> GetProductById(int? id)
        {
            try
            {
                Product product;

                if (id != null)
                {
                    product = await _productRepository.GetProductById(id);
                }
                else
                {
                    throw new Exception("Impossível fazer busca com id nulo");
                }

                return product;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                var productList = await _productRepository.GetProducts();

                return productList;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Update(Product product)
        {
            try
            {
                if (product != null)
                {
                    return await _productRepository.Update(product);
                }
                else
                {
                    throw new Exception("Produto vazio");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
