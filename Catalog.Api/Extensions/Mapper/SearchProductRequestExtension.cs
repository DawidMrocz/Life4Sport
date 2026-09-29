using Catalog.Api.ApiModels.Product.Request;
using Catalog.Api.DTO;

namespace Catalog.Api.Extensions.Mapper
{
    public static class SearchProductRequestExtension
    {
        public static SearchProductRequestDto ToSearchProductRequestDto(this SearchProductRequest request)
        {
            return new SearchProductRequestDto();
        }
    }
}
