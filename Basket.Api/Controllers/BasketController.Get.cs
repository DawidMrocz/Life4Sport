using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    public partial class BasketController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            if(AuthorizedUser is null) return Unauthorized();
            await _basketService.Get(AuthorizedUser.Id);
            return Ok("Pomyślnie dodano zniżkę");
        }
    }
}
