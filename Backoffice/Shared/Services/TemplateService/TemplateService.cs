using Framework.Shared.Attribiutes.Dependency;
using Framework.Shared.Data;
using Framework.Shared.Models.Template;
using Microsoft.EntityFrameworkCore;

namespace Framework.Shared.Services.TemplateService
{
    [DependencyInjection(typeof(ITemplateService))]
    internal class TemplateService : ITemplateService
    {
        private readonly FrameworkDbContext _frameworkDbContext;

        public TemplateService(FrameworkDbContext sharedDbContext)
        {
            _frameworkDbContext = sharedDbContext;
        }
        public async Task<TemplateModel?> Get(string templateName, int culture)
        {
            return await _frameworkDbContext.Templates.Where(t => t.Name == templateName && t.CultureId == culture).FirstOrDefaultAsync();
        }
    }
}
