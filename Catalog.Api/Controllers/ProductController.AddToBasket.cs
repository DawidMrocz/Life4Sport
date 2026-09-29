using Catalog.Api.ApiModels.Product.Request;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    public partial class ProductController
    {
        [HttpPost("{productId}/[action]")]
        public async Task<IActionResult> AddToBasket([FromRoute] int productId)
        {
            try
            {
                if(AuthorizedUser is null) return Unauthorized();

                await _productService.AddToBasket(AuthorizedUser.Id,productId);
                return Ok("Pomyślnie dodano do koszyka");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
