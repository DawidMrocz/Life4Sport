using Catalog.Api.ApiModels.Product.Request;
using Catalog.Api.Extensions.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    public partial class ProductController
    {
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SearchProductRequest request)
        {
            try
            {
                return Ok(await _productService.Search(request.ToSearchProductRequestDto()));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
