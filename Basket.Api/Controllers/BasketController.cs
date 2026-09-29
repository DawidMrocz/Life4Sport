using Basket.Api.Services.Basket;
using Framework.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("[controller]")]
    public partial class BasketController : AuthorizedController
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _basketService = basketService;
        }
    }
}
