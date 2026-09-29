using Basket.Api.Services.BasketItem;
using Framework.Shared.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("[controller]")]
    public partial class BasketItemController : AuthorizedController
    {
        private readonly IBasketItemService _basketItemService;
        public BasketItemController(IServiceProvider serviceProvider, IBasketItemService basketItemService) : base(serviceProvider)
        {
            _basketItemService = basketItemService;
        }
    }
}
