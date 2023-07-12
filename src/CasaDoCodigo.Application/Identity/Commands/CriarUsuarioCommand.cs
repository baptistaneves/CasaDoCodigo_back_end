using CasaDoCodigo.Application
    .Identity.Validations;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Application.Identity.Commands;

public class CriarUsuarioCommand : Command<IdentityUserResponse>
{
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public string Perfil { get; private set; }

    public CriarUsuarioCommand(string email, string senha, string perfil)
    {
        Email = email;
        Senha = senha;
        Perfil = perfil;
    }

    public override bool IsValid()
    {
        ValidationResult = new CriarUsuarioCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
