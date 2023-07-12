namespace CasaDoCodigo.Application.Validations.Categorias;

internal class CriarCategoriaValidation : AbstractValidator<CriarCategoria>
{
	public CriarCategoriaValidation()
	{
		RuleFor(c => c.Descricao)
			.NotEmpty().WithMessage("A descrição deve ser informada")
			.MinimumLength(4).WithMessage("A descrição deve ter no minímo 4 caracteres");
	}
}

internal class ActualizarCategoriaValidation : AbstractValidator<ActualizarCategoria>
{
    public ActualizarCategoriaValidation()
    {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty).WithMessage("O Id da categoria não foi informado");

        RuleFor(c => c.Descricao)
            .NotEmpty().WithMessage("A descrição deve ser informada")
            .MinimumLength(4).WithMessage("A descrição deve ter no minímo 4 caracteres");
    }
}
