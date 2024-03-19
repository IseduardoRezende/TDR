using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TDRData.Models;

namespace TDR.Models
{
    public class User : BaseModel
    {
        public User()
        {
            Votes = new List<Vote>();
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        [ForeignKey("Period")]
        public long PeriodFk { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Period Period { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
