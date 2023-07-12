namespace CasaDoCodigo.Application.Identity.Validations;

internal class LoginUsuarioCommandValidation : AbstractValidator<LoginUsuarioCommand>
{
    public LoginUsuarioCommandValidation()
    {
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("O e-mail deve ser informado");

        RuleFor(u => u.Senha)
            .NotEmpty().WithMessage("A senha deve ser informada");

    }
}