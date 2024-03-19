using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TDR.ViewModels.Usuario
{
    public class UpdateUserViewModel : BaseUpdateViewModel
    {
        [Required(ErrorMessage = "Campo Email é necessário"), DisplayName("Email Institucional"), 
         DataType(DataType.EmailAddress), MaxLength(256, ErrorMessage = "Email deve conter no máximo 256 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Senha é necessário"), DisplayName("Senha"), DataType(DataType.Password),
          MinLength(6, ErrorMessage = "Senha deve conter no mínimo 6 caracteres"),
          MaxLength(21, ErrorMessage = "Senha deve conter no máximo 21 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo Confirmação de Senha é necessário"), DisplayName("Confirmar Senha"), DataType(DataType.Password),
         MinLength(6, ErrorMessage = "Senha deve conter no mínimo 6 caracteres"),
         MaxLength(21, ErrorMessage = "Senha deve conter no máximo 21 caracteres")]
        public string ConfirmPassword { get; set; }

        public string? Salt { get; set; }

        [Required(ErrorMessage = "Campo Período é necessário"), DisplayName("Período"), Range(1, 2)]
        public long PeriodFk { get; set; }           
    }
}
