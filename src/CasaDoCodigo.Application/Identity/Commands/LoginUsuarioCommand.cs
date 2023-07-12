namespace CasaDoCodigo.Application.Identity.Commands;

public class LoginUsuarioCommand : Command<IdentityUserResponse>
{
    public string Email { get; private set; }

    public string Senha { get; private set; }

    public LoginUsuarioCommand(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }

    public override bool IsValid()
    {
        ValidationResult = new LoginUsuarioCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
