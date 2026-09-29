using Framework.Shared.Models.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Shared.Services.TemplateService
{
    public interface ITemplateService
    {
        Task<TemplateModel?> Get(string templateName, int culture);
    }
}
