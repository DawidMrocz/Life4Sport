using Framework.Shared.Attribiutes.Dependency;
using Framework.Shared.Services.FileService;
using Home.Data;
using Home.Dto.Product;
using Home.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace Home.Services.Product
{
    [DependencyInjection(typeof(IProductService))]
    public partial class ProductService : IProductService
    {
        private readonly ProductDbContext _productDbContext;
        //private readonly IFileService _fileService;

        public ProductService(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
           // _fileService = fileService;
        }

        public async Task Create(CreateProductRequest request)
        {
            ProductModel model = new()
            {
                Name = request.Name,
                Description = request.Description,
                Quantity = request.Quantity,
                Price = request.Price,
                Season = request.Season
            };

            await _productDbContext.Products.AddAsync(model);
            await _productDbContext.SaveChangesAsync();
        }

        public async Task Delete(int productId)
        {
            ProductModel model = await Get(productId);
            _productDbContext.Remove(model);
            await _productDbContext.SaveChangesAsync();
        }

        public async Task<List<ProductModel>> Search(SearchProductRequestDto request)
        {
            return await _productDbContext.Products.ToListAsync();
        }

        public async Task Update(int productId, UpdateProductRequest request)
        {
            ProductModel model = await Get(productId);

            model.Name = request.Name ?? model.Name;
            model.Description = request.Description ?? model.Description;
            model.Quantity = request.Quantity ?? model.Quantity;
            model.Price = request.Price ?? model.Price;
            model.Season = request.Season ?? model.Season;

            await _productDbContext.SaveChangesAsync();
        }

        public async Task<ProductModel> Get(int productId)
        {
            return await _productDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId)
                ?? throw new Exception("Product not found");
        }
    }
}
