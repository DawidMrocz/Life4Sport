using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    public partial class ProductController
    {
        [HttpGet("{productId}")]
        public async Task<IActionResult> Get([FromRoute] int productId)
        {
            try
            {
                return Ok(await _productService.Get(productId));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
