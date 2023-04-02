using Finanblue.Domain.Entities;
using Finanblue.Domain.Interfaces;
using Finanblue.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Finanblue.Infra.Data.Repositories
{
    public class ProductsPurchaseRepository : IProductsPurchaseRepository
    {
        private ApiDbContext _dbContext;

        public ProductsPurchaseRepository(ApiDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductsPurchase>> GetProductsPurchases()
        {
            return await _dbContext.ProductsPurchase.ToListAsync();
        }

        public async Task<ProductsPurchase> GetProductsPurchaseById(int? id)
        {
            return await _dbContext.ProductsPurchase.FindAsync(id);
        }

        public async Task<List<ProductsPurchase>> GetProductsPurchaseByPurchaseId(int? id)
        {
            return await _dbContext.ProductsPurchase.Where(x=> x.PurchaseId == id).ToListAsync();
        }

        public async Task<bool> Add(ProductsPurchase productsPurchase)
        {
            try
            {
                _dbContext.ProductsPurchase.Add(productsPurchase);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(ProductsPurchase productsPurchase)
        {

            try
            {
                _dbContext.ProductsPurchase.Update(productsPurchase);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool Delete(int id)
        {
            try
            {
                var productsPurchase = _dbContext.ProductsPurchase.Where(d => d.Id == id).FirstOrDefault();
                if (productsPurchase != null)
                {
                    _dbContext.ProductsPurchase.Remove(productsPurchase);
                    _dbContext.SaveChanges();
                    return true;
                }

                return false;

            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
