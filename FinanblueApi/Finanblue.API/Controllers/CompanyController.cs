using Finanblue.Application.Interfaces;
using Finanblue.Application.Services;
using Finanblue.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Finanblue.API.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Company))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Company> data = await _companyService.GetAll();

                return data == null ? NotFound() : Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Company))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Company data = await _companyService.GetCompanyById(id);

                return data == null ? NotFound() : Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Company))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/Post")]
        public async Task<IActionResult> Post([FromBody] Company company)
        {
            try
            {
                bool data = await _companyService.Add(company);

                return !data ? NotFound() : Ok(company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Company))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/Put")]
        public async Task<IActionResult> Put([FromBody] Company company)
        {
            try
            {
                bool data = await _companyService.Update(company);

                return !data ? NotFound() : Ok(company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Company))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool data = _companyService.Delete(id);

                return !data ? NotFound() : Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
