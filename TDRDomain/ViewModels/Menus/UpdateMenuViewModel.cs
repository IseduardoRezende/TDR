using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TDR.ViewModels.Cardapios
{
    public class UpdateMenuViewModel : BaseUpdateViewModel
    {
        [Required(ErrorMessage = "Nome da refeição é necessária"),
        DisplayName("Refeição")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Data do Cardapio é necessário"),
        DataType(DataType.Date),
        DisplayName("Data")]
        public DateTime Date { get; set; }

        public long PeriodFk { get; set; }

        [Required(ErrorMessage = "Intervalo inicial para votos é necessário"),
        DataType(DataType.DateTime),
        DisplayName("Intervalo para Votos Inicial")]
        public DateTime StartVote { get; set; }

        [Required(ErrorMessage = "Intervalo final para votos é necessário"),
        DataType(DataType.DateTime),
        DisplayName("Intervalo para Votos Final")]
        public DateTime EndVote { get; set; }
    }
}
