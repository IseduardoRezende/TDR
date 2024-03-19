using System.ComponentModel;

namespace TDR.ViewModels.Usuario
{
    public class ReadUserViewModel : BaseReadViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public long PeriodFk { get; set; }

        [DisplayName("Período")]
        public string PeriodDescription { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
