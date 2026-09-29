using Catalog.Api.Services.Producer;
using Framework.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("[controller]")]
    public partial class ProducerController : AuthorizedController
    {
        private readonly IProducerService _producerService;

        public ProducerController(IServiceProvider serviceProvider, IProducerService producerService) : base(serviceProvider)
        {
            _producerService = producerService;
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            try
            {
                return Ok(await _producerService.GetList());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
