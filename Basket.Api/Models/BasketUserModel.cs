using Common;
using Framework.Shared.Models.Token;
using Framework.Shared.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basket.Api.Models
{
    public class BasketUserModel : IExternal
    {
        [Key]
        public int BasketUserId { get; set; }
        public int ExternalId { get; set; }
        [Index("IX_EmailLogin", 1, IsUnique = true)]
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Files Files { get; set; } = new();
        public Address? Address { get; set; }
        public BasketModel Basket { get; set; } = new();
        public List<DiscountModel> Discounts { get; set; } = new();
    }
}
