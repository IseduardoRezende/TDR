using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDR.Models
{
    public class Vote : BaseModel
    {
        public bool State { get; set; }

        public ushort InteractionsNumber { get; set; } 

        [ForeignKey("User")]
        public long UserFk { get; set; }

        [ForeignKey("Menu")]
        public long MenuFk { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User User { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Menu Menu { get; set; }
    }
}
