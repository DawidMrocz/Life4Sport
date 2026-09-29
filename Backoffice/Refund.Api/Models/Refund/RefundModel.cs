using System.ComponentModel.DataAnnotations;

namespace Refund.Api.Models.Refund
{
    public class RefundModel
    {
        [Key]
        public int RefundId { get; set; }
    }
}
