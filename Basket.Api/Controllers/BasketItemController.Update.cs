using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    public partial class BasketItemController
    {
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int basketItemId,[FromBody] int quantity)
        {
            if(AuthorizedUser is null) return Unauthorized();

            await _basketItemService.Update(basketItemId, quantity, AuthorizedUser.Id);
            return Ok("Pomyślnie dodano zniżkę");
        }
    }
}
