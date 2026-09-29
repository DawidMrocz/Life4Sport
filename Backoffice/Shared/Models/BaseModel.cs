using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Shared.Models
{
    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? Created { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? Updated { get; set; }
    }
}
