using Finanblue.Domain.Entities;

namespace Finanblue.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int? id);

        bool Delete(int id);
        Task<bool> Add(Product product);
        Task<bool> Update(Product product);
    }
}
