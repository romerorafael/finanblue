using Finanblue.Application.Interfaces;
using Finanblue.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Finanblue.API.Controllers
{
    [ApiController]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IProductsPurchaseService _productsPurchaseService;

        public PurchaseController(IPurchaseService purchaseService, IProductsPurchaseService productsPurchaseService)
        {
            _purchaseService = purchaseService;
            _productsPurchaseService = productsPurchaseService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Purchase))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Purchase> data = await _purchaseService.GetAll();

                return data == null ? NotFound() : Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Purchase))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Purchase data = await _purchaseService.GetPurchaseById(id);

                return data == null ? NotFound() : Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Purchase))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/Post")]
        public async Task<IActionResult> Post([FromBody] PurchaseBody purchaseBody )
        {
            try
            {
                int data = await _purchaseService.Add(purchaseBody.Purchase);
                foreach (Product product in purchaseBody.Products)
                {
                    var purchaseProduct = new ProductsPurchase
                    {
                        ProductId = product.Id,
                        PurchaseId = purchaseBody.Purchase.Id,
                    };
                    await _productsPurchaseService.Add(purchaseProduct);
                }

                return data == 0 ? NotFound() : Ok(purchaseBody.Purchase);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Purchase))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/Put")]
        public async Task<IActionResult> Put([FromBody] Purchase purchase)
        {
            try
            {
                bool data = await _purchaseService.Update(purchase);

                return !data ? NotFound() : Ok(purchase);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Purchase))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/[controller]/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool data = _purchaseService.Delete(id);

                return !data ? NotFound() : Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
