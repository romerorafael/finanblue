using Finanblue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanblue.Application.Interfaces
{
    public  interface IProductsPurchaseService
    {
        Task<IEnumerable<ProductsPurchase>> GetProductsPurchases();
        Task<ProductsPurchase> GetProductsPurchaseById(int? id);
        Task<List<ProductsPurchase>> GetProductsPurchaseByPurchaseId(int? purchaseId);

        bool Delete(int id);
        Task<bool> Add(ProductsPurchase productspurchase);
        Task<bool> Update(ProductsPurchase productspurchase);
    }
}
