using Catalog.Api.ApiModels.Product.Request;
using Catalog.Api.Data;
using Catalog.Api.DTO;
using Catalog.Api.Models;
using Catalog.Api.Services.Product;
using Common.MassTransit;
using Framework.Shared.Attribiutes.Dependency;
using Framework.Shared.Models.File;
using Framework.Shared.Services.FileService;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Services.Products
{
    [DependencyInjection(typeof(IProductService))]
    public partial class ProductService : IProductService
    {
        private readonly CatalogContext _catalogContext;
        private readonly IFileService _fileService;
        private readonly IPublishEndpoint _publishEndpoint;

        public ProductService(CatalogContext catalogContext, IFileService fileService, IPublishEndpoint publishEndpoint)
        {
            _catalogContext = catalogContext;
            _fileService=fileService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task AddToBasket(int userId, int productId)
        {
            ProductModel? model = await _catalogContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId)
                ?? throw new ArgumentNullException(nameof(productId));

            if (!model.IsAvailable) throw new Exception("Product is not available");

            model.Quantity--;

            await _catalogContext.SaveChangesAsync();

            //SEND EVENT TO BASKET VIA RABBIT
            await _publishEndpoint.Publish(new AddToBasketCommand(userId, productId, model.Quantity));
        }

        public async Task<GetProductResponseDto> Get(int productId)
        {
            ProductModel? model = await _catalogContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId)
                ?? throw new ArgumentNullException(nameof(productId));

            return new GetProductResponseDto(model);
        }

        public async Task<List<ProductModel>> Search(SearchProductRequestDto request)
        {
            return await _catalogContext.Products.ToListAsync();
        }
    }
}
