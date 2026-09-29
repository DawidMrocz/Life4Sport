using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Repositories.BasketItem
{
    public interface IBasketItemRepository
    {
        Task Create();
        Task Delete();
        Task Update();
    }
}
