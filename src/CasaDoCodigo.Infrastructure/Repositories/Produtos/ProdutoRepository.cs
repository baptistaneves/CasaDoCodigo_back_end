namespace CasaDoCodigo.Infrastructure.Repositories.Produtos;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(ApplicationDbContext context) : base(context)
    {
    }
}
