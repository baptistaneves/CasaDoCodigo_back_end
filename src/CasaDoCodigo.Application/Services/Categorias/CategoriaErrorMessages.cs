namespace CasaDoCodigo.Application.Services.Categorias;

internal class CategoriaErrorMessages
{
    public const string CategoriaJaExiste = "Já foi cadastrada uma Categoria com esta Descrição";
    public const string CategoriaNaoEncotrada = "Já foi encontrada nenhuma Categoria com este Id";
    public const string CategoriaNaoPodeSerRemovida = "Esta Categoria possui produtos cadastrados, não pode ser removida";
}
