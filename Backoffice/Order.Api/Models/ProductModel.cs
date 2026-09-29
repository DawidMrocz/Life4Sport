using Common;
using System.ComponentModel.DataAnnotations;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Order.Api.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class ProductModel : IExternal
    {
        [Key]
        public int ProductId { get; set; }
        public int ExternalId { get; set; }
        public string Name { get; set; } = null!;

        //RELATIONS
        public OrderItemModel OrderItem { get; set; } = new();
    }
}
