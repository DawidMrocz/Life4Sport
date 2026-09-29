using Framework.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;
using Raport.Api.Services;

namespace Raport.Api.Controllers
{
    [Route("[controller]")]
    public class RaportController : AuthorizedController
    {
        private readonly IRaportService _raportService;
        public RaportController(IServiceProvider serviceProvider, IRaportService raportService) : base(serviceProvider)
        {
            _raportService = raportService;
        }
    }
}
