using System.ComponentModel;

namespace TDR.ViewModels.Votacao
{
    public class ReadVoteViewModel : BaseReadViewModel
    {
        public bool State { get; set; } = true;

        [DisplayName("Voto")]
        public string StateText { get { return State ? "Vou comer" : "Não vou comer"; } }

        [DisplayName("Mudanças de Voto Restantes")]
        public ushort InteractionsNumber { get; set; }

        public long UserFk { get; set; }

        [DisplayName("Usuário")]
        public string UserEmail { get; set; }

        public long MenuFk { get; set; }

        [DisplayName("Refeição")]
        public string MenuName { get; set; }

        [DisplayName("Data Refeição")]
        public DateTime MenuDate { get; set; }

        public DateTime MenuStartVote { get; set; }

        public DateTime MenuEndVote { get; set; }
    }
}
