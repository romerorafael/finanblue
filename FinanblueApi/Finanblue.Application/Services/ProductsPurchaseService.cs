using Finanblue.Application.Interfaces;
using Finanblue.Domain.Entities;
using Finanblue.Domain.Interfaces;

namespace Finanblue.Application.Services
{
    public class ProductsPurchaseService : IProductsPurchaseService
    {
        private IProductsPurchaseRepository _productsProductsPurchaseRepository;

        public ProductsPurchaseService(IProductsPurchaseRepository productsProductsPurchaseRepository)
        {
            _productsProductsPurchaseRepository = productsProductsPurchaseRepository;
        }

        public async Task<bool> Add(ProductsPurchase productsProductsPurchase)
        {
            try
            {
                if (productsProductsPurchase != null)
                {                    
                    return await _productsProductsPurchaseRepository.Add(productsProductsPurchase); ;
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

                return _productsProductsPurchaseRepository.Delete(id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ProductsPurchase> GetProductsPurchaseById(int? id)
        {
            try
            {
                ProductsPurchase productsProductsPurchase;

                if (id != null)
                {
                    productsProductsPurchase = await _productsProductsPurchaseRepository.GetProductsPurchaseById(id);
                }
                else
                {
                    throw new Exception("Impossível fazer busca com id nulo");
                }

                return productsProductsPurchase;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ProductsPurchase>> GetProductsPurchaseByPurchaseId(int? purchaseId)
        {
            try
            {
                List<ProductsPurchase> productsProductsPurchase;

                if (purchaseId != null)
                {
                    productsProductsPurchase = await _productsProductsPurchaseRepository.GetProductsPurchaseByPurchaseId(purchaseId);
                }
                else
                {
                    throw new Exception("Impossível fazer busca com id nulo");
                }

                return productsProductsPurchase;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<ProductsPurchase>> GetProductsPurchases()
        {
            try
            {
                var productsProductsPurchaseList = await _productsProductsPurchaseRepository.GetProductsPurchases();

                return productsProductsPurchaseList;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Update(ProductsPurchase productsProductsPurchase)
        {
            try
            {
                if (productsProductsPurchase != null)
                {                    
                    return await _productsProductsPurchaseRepository.Update(productsProductsPurchase); ;
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
