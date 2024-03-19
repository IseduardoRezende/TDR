using System.ComponentModel;
using TDR.Enums;

namespace TDR.ViewModels.Cardapios
{
    public class ReadMenuViewModel : BaseReadViewModel
    {
        [DisplayName("Refeição")]
        public string Name { get; set; }

        [DisplayName("Data")]
        public DateTime Date { get; set; }
        
        [DisplayName("Quantidade de Votos")]
        public int QtyVotes { get; set; }

        public long PeriodFk { get; set; }

        [DisplayName("Período")]
        public string PeriodText
        { 
            get 
            {
                return PeriodFk == (long)PeriodType.Evening ? "Noturno" : "Matutino"; 
            } 
        }

        [DisplayName("Intervalo para Votos Inicial")]
        public DateTime StartVote { get; set; }

        [DisplayName("Intervalo para Votos Final")]
        public DateTime EndVote { get; set; }
    }
}
