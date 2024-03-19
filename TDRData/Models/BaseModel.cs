using System.ComponentModel.DataAnnotations;
using TDRData.Interface;

namespace TDR.Models
{
    public abstract class BaseModel : IBaseModel
    {
        [Key]
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? DeletedAt { get; set; }
    }
}
