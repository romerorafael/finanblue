using Finanblue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanblue.Domain.Interfaces
{
    public  interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetCompanyById(int? id);

        bool Delete(int id);
        Task<bool> Add(Company company);
        Task<bool> Update(Company company);
    }
}
