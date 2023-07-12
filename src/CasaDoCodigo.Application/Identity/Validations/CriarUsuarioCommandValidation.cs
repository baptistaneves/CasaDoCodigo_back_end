namespace CasaDoCodigo.Application.Identity.Validations;

internal class CriarUsuarioCommandValidation : AbstractValidator<CriarUsuarioCommand>
{
	public CriarUsuarioCommandValidation()
	{
		RuleFor(u => u.Email)
			.NotEmpty().WithMessage("O e-mail deve ser informado")
			.EmailAddress().WithMessage("O e-mail informado não é válido");

		RuleFor(u => u.Senha)
			.NotEmpty().WithMessage("A senha deve ser informada");

	}
}