using Finanblue.Application.Interfaces;
using Finanblue.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Finanblue.API.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) { 
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/GetAll")]
        public async Task<IActionResult> GetAll()
        {   
            try
            {
                IEnumerable <Product> data = await _productService.GetProducts();

                return data == null ? NotFound() : Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Product data = await _productService.GetProductById(id);

                return data == null ? NotFound() : Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/Post")]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            try
            {
                bool data = await _productService.Add(product);

                return !data ? NotFound() : Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/Put")]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            try
            {
                bool data = await _productService.Update(product);

                return !data ? NotFound() : Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool data = _productService.Delete(id);

                return !data ? NotFound() : Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
