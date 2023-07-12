using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Application.Contracts.Identity.Requests;

public class CriarUsuario
{
    [Required(ErrorMessage = "O e-mail deve ser informado")]
    [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha deve ser informada")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "O perfil deve ser informado")]
    public string Perfil { get; set; }
}


public class LoginUsuario
{
    [Required(ErrorMessage = "O e-mail deve ser informado")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha deve ser informada")]
    public string Senha { get; set; }
}