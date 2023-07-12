using CasaDoCodigo.Domain.Categorias;

namespace CasaDoCodigo.Application.Services.Categorias;

public class CategoriaService : BaseService, ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;
    public CategoriaService(INotifier notifier, 
                            ICategoriaRepository categoriaRepository) : base(notifier)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task Adicionar(CriarCategoria categoria, CancellationToken cancellationToken)
    {
        if (!Validate(new CriarCategoriaValidation(), categoria)) return;

        if(_categoriaRepository.SearchAsync(c => c.Descricao == categoria.Descricao).Result.Any())
        {
            Notify(CategoriaErrorMessages.CategoriaJaExiste);
            return;
        }

        _categoriaRepository.Add(new Categoria(categoria.Descricao));
        await _categoriaRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task Actualizar(ActualizarCategoria categoriaAct, CancellationToken cancellationToken)
    {
        if (!Validate(new ActualizarCategoriaValidation(), categoriaAct)) return;

        var categoria = await _categoriaRepository.GetByIdAsync(categoriaAct.Id);
        if (categoria == null)
        {
            Notify(CategoriaErrorMessages.CategoriaNaoEncotrada);
            return;
        }

        if (_categoriaRepository.SearchAsync(c => c.Descricao == categoriaAct.Descricao && c.Id != categoriaAct.Id).Result.Any())
        {
            Notify(CategoriaErrorMessages.CategoriaJaExiste);
            return;
        }

        categoria.Actualizar(categoriaAct.Descricao);

        _categoriaRepository.Update(categoria);
        await _categoriaRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

    }

    public async Task Remover(Categoria categoria, CancellationToken cancellationToken)
    {
        if(_categoriaRepository.VerificarSeCategoriaPossuiProdutosPorId(categoria.Id).Result.Produtos.Any())
        {
            Notify(CategoriaErrorMessages.CategoriaNaoPodeSerRemovida);
            return;
        }

        _categoriaRepository.Remove(categoria);
        await _categoriaRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<Categoria> ObterPorId(Guid id)
    {
        return await _categoriaRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Categoria>> ObterTodos()
    {
        return await _categoriaRepository.GetAllAsync();
    }

    public void Dispose()
    {
        _categoriaRepository?.Dispose();
    }
}
