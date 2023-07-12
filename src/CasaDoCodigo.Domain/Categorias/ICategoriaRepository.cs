namespace CasaDoCodigo.Domain.Categorias;

public interface ICategoriaRepository : IRepository<Categoria> 
{
    Task<Categoria> VerificarSeCategoriaPossuiProdutosPorId(Guid id);
}
