using Discount.Api.ApiModels;
using Discount.Api.Data;
using Discount.Api.Services.Product;
using Framework.Shared.Attribiutes.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Core.Services.Discount
{
    [DependencyInjection(typeof(IDiscountService))]
    internal partial class DiscountService : IDiscountService
    {
        private readonly DiscountDbContext _discountDbContext;
        private readonly IProductService _productService;

        public DiscountService(DiscountDbContext discountDbContext, IProductService productService)
        {
            _discountDbContext = discountDbContext;
            _productService = productService;
        }
    }
}
