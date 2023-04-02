using Finanblue.Domain.Entities;
using Finanblue.Domain.Interfaces;
using Finanblue.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Finanblue.Infra.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private ApiDbContext _dbContext;

        public CompanyRepository(ApiDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _dbContext.Company.ToListAsync();
        }

        public async Task<Company> GetCompanyById(int? id)
        {
            return await _dbContext.Company.FindAsync(id);
        }

        public async Task<bool> Add(Company company)
        {
            try
            {
                _dbContext.Company.Add(company);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(Company company)
        {

            try
            {
                _dbContext.Company.Update(company);
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
                var company = _dbContext.Company.Where(d => d.Id == id).FirstOrDefault();
                if (company != null)
                {
                    _dbContext.Company.Remove(company);
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
