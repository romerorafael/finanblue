using Finanblue.Domain.Entities;
using Finanblue.Domain.Interfaces;
using Finanblue.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Finanblue.Infra.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private ApiDbContext _dbContext;

        public PurchaseRepository(ApiDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Purchase>> GetAll()
        {
            return await _dbContext.Purchase.ToListAsync();
        }

        public async Task<Purchase> GetPurchaseById(int? id)
        {
            return await _dbContext.Purchase.FindAsync(id);
        }

        public async Task<int> Add(Purchase purchase)
        {
            try
            {
                _dbContext.Purchase.Add(purchase);
                _dbContext.SaveChanges();

                return purchase.Id;
            }
                catch (Exception)
            {
                return 0;
            }
        }
        public async Task<bool> Update(Purchase purchase)
        {

            try
            {
                _dbContext.Purchase.Update(purchase);
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
                var purchase = _dbContext.Purchase.Where(d => d.Id == id).FirstOrDefault();
                if (purchase != null)
                {
                    _dbContext.Purchase.Remove(purchase);
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
