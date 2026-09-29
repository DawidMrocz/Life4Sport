using Catalog.Api.ApiModels.Product.Request;
using Catalog.Api.Services.Category;
using Framework.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("[controller]")]
    public partial class CategoryController : AuthorizedController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(IServiceProvider serviceProvider,ICategoryService categoryService):base(serviceProvider)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            try
            {
                return Ok(await _categoryService.GetList());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
