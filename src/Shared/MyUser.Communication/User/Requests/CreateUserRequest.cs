using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUser.Communication.User.Requests;
public class CreateUserRequest : Request
{
    [Required(ErrorMessage = "Nome inválido")]
    [MinLength(3, ErrorMessage = "O Nome deve conter no minimo 3 caracteres")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Email inválido")]
    [EmailAddress]
    public string Email { get; set; }
    [MinLength(7, ErrorMessage = "A senha deve conter no minimo 7 caracteres")]
    [MaxLength(26, ErrorMessage = "A senha não pode exceder 26 caracteres")]
    public string Password { get; set; }
    [RegularExpression(@"^\d{2} \d{2} \d{4}-\d{4}$", ErrorMessage = "O telefone deve seguir o formato XX XX XXXX-XXXX")]
    public string Phone { get; set; }
    public string CEP { get; set; }
}
