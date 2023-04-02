using Finanblue.Domain.Entities;

namespace Finanblue.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetCompanyById(int? id);

        bool Delete(int id);
        Task<bool> Add(Company company);
        Task<bool> Update(Company company);
    }
}
