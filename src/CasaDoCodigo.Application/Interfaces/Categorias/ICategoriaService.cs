namespace CasaDoCodigo.Application.Interfaces.Categorias;

public interface ICategoriaService : IDisposable
{
    Task Adicionar(CriarCategoria categoria, CancellationToken cancellationToken);
    Task Actualizar(ActualizarCategoria categoria, CancellationToken cancellationToken);
    Task Remover(Categoria categoria, CancellationToken cancellationToken);
    Task<Categoria> ObterPorId(Guid id);
    Task<IEnumerable<Categoria>> ObterTodos();
}
