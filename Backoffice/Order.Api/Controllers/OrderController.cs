using Framework.Shared.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Api.Dto;
using Order.Api.Services;

namespace Order.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : AuthorizedController
    {
        private readonly IOrderService _orderService;

        public OrderController(IServiceProvider serviceProvider, IOrderService orderService) : base(serviceProvider)
        {
            _orderService = orderService;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> Get([FromRoute] int orderId)
        {
            try
            {
                return Ok(await _orderService.Get(orderId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromBody] SearchOrderRequest request)
        {
            try
            {
                return Ok(await _orderService.Search(request));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            try
            {
                await _orderService.Create(request);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int orderId, [FromBody] UpdateOrderRequest request)
        {
            try
            {
                await _orderService.Update(orderId, request);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int orderId)
        {
            try
            {
                await _orderService.Delete(orderId);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
