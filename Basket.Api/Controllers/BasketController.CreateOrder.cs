using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    public partial class BasketController
    {
        [HttpPost("/create-order")]
        public async Task<IActionResult> CreateOrder()
        {
            if (AuthorizedUser is null) return Unauthorized();

            await _basketService.CreateOrder(AuthorizedUser.Id);
            return Ok("Pomyślnie dodano zniżkę");
        }
    }
}
