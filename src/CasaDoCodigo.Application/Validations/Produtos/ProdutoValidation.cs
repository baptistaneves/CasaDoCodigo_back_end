namespace CasaDoCodigo.Application.Validations.Produtos;

internal class CriarProdutoValidation : AbstractValidator<CriarProduto>
{
	public CriarProdutoValidation()
	{
		RuleFor(p => p.Titulo)
            .NotEmpty().WithMessage("O titulo deve ser informado")
            .MinimumLength(4).WithMessage("O titulo deve ter no minímo 4 caracteres");

        RuleFor(p => p.Imagem)
            .NotEmpty().WithMessage("Selecione uma imagem para o produto");

        RuleFor(c => c.CategoriaId)
            .NotEqual(Guid.Empty).WithMessage("O categoria deve ser informada");
    }
}

internal class ActualizarProdutoValidation : AbstractValidator<ActualizarProduto>
{
    public ActualizarProdutoValidation()
    {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty).WithMessage("O Id do produto não foi informado");

        RuleFor(p => p.Titulo)
            .NotEmpty().WithMessage("O titulo deve ser informado")
            .MinimumLength(4).WithMessage("O titulo deve ter no minímo 4 caracteres");

        RuleFor(p => p.Imagem)
            .NotEmpty().WithMessage("Selecione uma imagem para o produto");

        RuleFor(c => c.CategoriaId)
            .NotEqual(Guid.Empty).WithMessage("O categoria deve ser informada");
    }
}
