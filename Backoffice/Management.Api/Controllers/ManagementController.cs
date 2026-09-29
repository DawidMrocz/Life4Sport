using Framework.Shared.Controllers;
using Management.Api.Dto;
using Management.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagementController : AuthorizedController
    {
        private readonly IManagementService _managementService;

        public ManagementController(IServiceProvider serviceProvider, IManagementService managementService) : base(serviceProvider)
        {
            _managementService = managementService;
        }

        [HttpGet("{managementId}")]
        public async Task<IActionResult> Get([FromRoute] int managementId)
        {
            try
            {
                return Ok(await _managementService.Get(managementId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromBody] SearchManagementRequest request)
        {
            try
            {
                return Ok(await _managementService.Search(request));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateManagementRequest request)
        {
            try
            {
                await _managementService.Create(request);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int managementId, [FromBody] UpdateManagementRequest request)
        {
            try
            {
                await _managementService.Update(managementId, request);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int managementId)
        {
            try
            {
                await _managementService.Delete(managementId);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
