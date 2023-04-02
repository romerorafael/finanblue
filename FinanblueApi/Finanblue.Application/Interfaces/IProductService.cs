using Finanblue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanblue.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int? id);

        bool Delete(int id);
        Task<bool> Add(Product product);
        Task<bool> Update(Product product);

    }
}
