using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ApiClient
{
    public class GetDiscountResponse
    {
        public int DiscountId { get; set; }
        public string Code { get; set; } = null!;
        public decimal Percentage { get; set; }
        public DateTime ValidTo { get; set; }

        //RELATIONS
        public List<int> Products { get; set; } = new();
    }
}
