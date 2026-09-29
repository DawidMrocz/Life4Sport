using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    public partial class BasketController
    {
        [HttpPost("/add-discount")]
        public async Task<IActionResult> AddDiscount([FromBody] string discountCode)
        {
            if(AuthorizedUser is null) return Unauthorized();
            await _basketService.AddDiscount(AuthorizedUser.Id,discountCode);
            return Ok("Pomyślnie dodano zniżkę");
        }
    }
}
