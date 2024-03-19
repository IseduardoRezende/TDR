using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TDRData.Models;

namespace TDR.Models
{
    public class Menu : BaseModel
    {
        public Menu()
        {
            Votes = new List<Vote>();
        }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("Period")]
        public long PeriodFk { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Period Period { get; set; }

        public DateTime StartVote { get; set; }

        public DateTime EndVote { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
