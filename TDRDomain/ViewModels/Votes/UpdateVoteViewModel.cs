using System.ComponentModel;

namespace TDR.ViewModels.Votacao
{
    public class UpdateVoteViewModel : BaseUpdateViewModel
    {
        [DisplayName("Voto")]
        public bool State { get; set; }

        public ushort InteractionsNumber { get; set; }

        public long UserFk { get; set; }

        public long MenuFk { get; set; }

        [DisplayName("Refeição")]
        public string MenuName { get; set; }

        [DisplayName("Data Refeição")]
        public DateTime MenuDate { get; set; }
    }
}
