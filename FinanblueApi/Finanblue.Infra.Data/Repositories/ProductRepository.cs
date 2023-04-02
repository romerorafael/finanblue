using Finanblue.Domain.Entities;
using Finanblue.Domain.Interfaces;
using Finanblue.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Finanblue.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApiDbContext _dbContext;

        public ProductRepository(ApiDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

       public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int? id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<bool> Add(Product product) {
            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(Product product) {

            try
            {
                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            

        }
        public bool Delete(int id) {
            try
            {
                var product = _dbContext.Products.Where(d => d.Id == id).FirstOrDefault();
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
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
