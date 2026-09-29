using Catalog.Api.Data;
using Common;
using Framework.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Api.Models
{
    [EntityTypeConfiguration(typeof(CommentConfiguration))]
    public class CommentModel : BaseModel
    {
        [Key]
        public int CommentId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Rating { get; set; }
        public int UserId { get; set; }

        //RELATIONS
        public int ProductId { get; set; }
        public ProductModel Product { get; set; } = new();
    }
}
