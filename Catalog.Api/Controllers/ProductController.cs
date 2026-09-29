using Catalog.Api.Services.Product;
using Framework.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("[controller]")]
    public partial class ProductController : AuthorizedController
    {
        private readonly IProductService _productService;

        public ProductController(IServiceProvider serviceProvider,IProductService productService):base(serviceProvider)
        {
            _productService = productService;
        }
    }
}
