using Finanblue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanblue.Application.Interfaces
{
    public interface IPurchaseService
    {
        Task<IEnumerable<Purchase>> GetAll();
        Task<Purchase> GetPurchaseById(int? id);

        bool Delete(int id);
        Task<int> Add(Purchase purchase);
        Task<bool> Update(Purchase purchase);
    }
}
