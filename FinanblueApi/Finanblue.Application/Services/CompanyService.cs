using Finanblue.Domain.Entities;
using Finanblue.Domain.Interfaces;
using Finanblue.Application.Interfaces;


namespace Finanblue.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> Add(Company company)
        {
            try
            {
                if (company != null)
                {
                    return await _companyRepository.Add(company);
                }
                else
                {
                    throw new Exception("Empresa vazia");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public bool Delete(int id)
        {
            try
            {

                return _companyRepository.Delete(id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Company> GetCompanyById(int? id)
        {
            try
            {
                Company company;

                if (id != null)
                {
                    company = await _companyRepository.GetCompanyById(id);
                }
                else
                {
                    throw new Exception("Impossível fazer busca com id nulo");
                }

                return company;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            try
            {
                var companyList = await _companyRepository.GetAll();

                return companyList;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Update(Company company)
        {
            try
            {
                if (company != null)
                {
                    return await _companyRepository.Update(company);
                }
                else
                {
                    throw new Exception("Produto vazio");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}
