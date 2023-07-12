namespace CasaDoCodigo.Application.Interfaces.Produtos;

public interface IProdutoService : IDisposable
{
    Task Adicionar(CriarProduto produto, CancellationToken cancellationToken);
    Task Actualizar(ActualizarProduto produto, CancellationToken cancellationToken);
    Task Remover(Produto produto, CancellationToken cancellationToken);
    Task<Produto> ObterPorId(Guid id);
    Task<IEnumerable<Produto>> ObterTodos();
}
