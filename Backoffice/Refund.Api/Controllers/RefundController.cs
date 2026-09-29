using Framework.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Refund.Api.Dto.Refund;
using Refund.Api.Services;

namespace Refund.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RefundController : AuthorizedController
    {
        private readonly IRefundService _refundService;

        public RefundController(IServiceProvider serviceProvider, IRefundService refundService) : base(serviceProvider)
        {
            _refundService = refundService;
        }

        [HttpGet("{refundId}")]
        public async Task<IActionResult> Get([FromRoute] int refundId)
        {
            try
            {
                return Ok(await _refundService.Get(refundId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromBody] SearchRefundRequest request)
        {
            try
            {
                return Ok(await _refundService.Search(request));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRefundRequest request)
        {
            try
            {
                await _refundService.Create(request);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int refundId, [FromBody] UpdateRefundRequest request)
        {
            try
            {
                await _refundService.Update(refundId, request);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int refundId)
        {
            try
            {
                await _refundService.Delete(refundId);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
