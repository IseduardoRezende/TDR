using System.ComponentModel;
using TDRDomain.ViewModels;

namespace TDR.ViewModels.Votacao
{
    public class CreateVoteViewModel : BaseCreateViewModel
    {
        [DisplayName("Voto")]
        public bool State { get; set; } = true;

        public ushort InteractionsNumber { get; set; } = 3;

        public long UserFk { get; set; }
        
        public long MenuFk { get; set; }

        [DisplayName("Refeição")]
        public string MenuName { get; set; }

        [DisplayName("Data Refeição")]
        public DateTime MenuDate { get; set; }
    }
}
