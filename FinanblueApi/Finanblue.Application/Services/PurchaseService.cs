using Finanblue.Application.Interfaces;
using Finanblue.Domain.Entities;
using Finanblue.Domain.Interfaces;

namespace Finanblue.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private IPurchaseRepository _purchaseRepository;
        private IProductsPurchaseRepository _productsPurchaseRepository;
        private IProductRepository _productRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository, IProductsPurchaseRepository productsPurchaseRepository, IProductRepository productRepository)
        {
            _purchaseRepository = purchaseRepository;            
            _productsPurchaseRepository = productsPurchaseRepository;
            _productRepository = productRepository;
        }

        public async Task<int> Add(Purchase purchase)
        {
            try
            {
                if (purchase != null)
                {
                   return await _purchaseRepository.Add(purchase);
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

                return _purchaseRepository.Delete(id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Purchase> GetPurchaseById(int? id)
        {
            try
            {
                Purchase purchase;

                if (id != null)
                {
                    purchase = await _purchaseRepository.GetPurchaseById(id);
                }
                else
                {
                    throw new Exception("Impossível fazer busca com id nulo");
                }

                return purchase;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Purchase>> GetAll()
        {
            try
            {
                List<Purchase> purchaseList = (List<Purchase>)await _purchaseRepository.GetAll();

                foreach (Purchase purchase in purchaseList)
                {
                    var productsList = new List<Product>();
                    var productPurchaseList = await _productsPurchaseRepository.GetProductsPurchaseByPurchaseId(purchase.Id);
                    foreach (var productPurchase in productPurchaseList)
                    {
                        var product = await _productRepository.GetProductById(productPurchase.ProductId);
                        productsList.Add(product);
                    }

                    purchase.Products = productsList;
                }

                return purchaseList;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Update(Purchase purchase)
        {
            try
            {
                if (purchase != null)
                {
                   
                    return await _purchaseRepository.Update(purchase); 

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
