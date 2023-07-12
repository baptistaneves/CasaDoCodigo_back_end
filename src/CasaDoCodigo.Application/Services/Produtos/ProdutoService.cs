namespace CasaDoCodigo.Application.Services.Produtos;

public class ProdutoService : BaseService, IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    public ProdutoService(INotifier notifier, 
                          IProdutoRepository produtoRepository) : base(notifier)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task Adicionar(CriarProduto produto, CancellationToken cancellationToken)
    {
        if (!Validate(new CriarProdutoValidation(), produto)) return;

        if (_produtoRepository.SearchAsync(c => c.Titulo == produto.Titulo).Result.Any())
        {
            Notify(ProdutoErrorMessages.ProdutoJaExiste);
            return;
        }

        _produtoRepository.Add(new Produto(produto.Titulo, produto.Descricao, produto.Imagem, produto.CategoriaId));
        await _produtoRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task Actualizar(ActualizarProduto produtoAct, CancellationToken cancellationToken)
    {
        if (!Validate(new ActualizarProdutoValidation(), produtoAct)) return;

        var produto = await _produtoRepository.GetByIdAsync(produtoAct.Id);
        if (produto == null)
        {
            Notify(ProdutoErrorMessages.ProdutoNaoEncotrado);
            return;
        }

        if (_produtoRepository.SearchAsync(c => c.Titulo == produtoAct.Titulo && c.Id != produtoAct.Id).Result.Any())
        {
            Notify(ProdutoErrorMessages.ProdutoJaExiste);
            return;
        }

        produto.Actualizar(produtoAct.Titulo, produtoAct.Descricao, produtoAct.Imagem, produtoAct.CategoriaId);

        _produtoRepository.Update(produto);
        await _produtoRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<Produto> ObterPorId(Guid id)
    {
        return await _produtoRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Produto>> ObterTodos()
    {
        return await _produtoRepository.GetAllAsync();
    }

    public async Task Remover(Produto produto, CancellationToken cancellationToken)
    {
        _produtoRepository.Remove(produto);
        await _produtoRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _produtoRepository?.Dispose();
    }
}
