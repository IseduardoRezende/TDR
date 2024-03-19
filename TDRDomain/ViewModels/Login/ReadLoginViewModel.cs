using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TDR.ViewModels.Login
{
    public class ReadLoginViewModel
    {
        [Required(ErrorMessage = "Campo Email é necessário"), DataType(DataType.EmailAddress), 
         MaxLength(256, ErrorMessage = "Email deve conter no máximo 256 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Senha é necessário"), DisplayName("Senha"), DataType(DataType.Password),
         MinLength(6, ErrorMessage = "Senha deve conter no mínimo 6 caracteres"),
         MaxLength(21, ErrorMessage = "Senha deve conter no máximo 21 caracteres")]
        public string Password { get; set; }
    }
}
