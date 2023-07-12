namespace CasaDoCodigo.API.Controllers.v1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
[Authorize]
public class ProdutosController : BaseController
{
    private readonly IProdutoService _produtoService;
    public ProdutosController(INotifier notifier, IProdutoService produtoService) : base(notifier)
    {
        _produtoService = produtoService;
    }

    [HttpGet(ApiRoutes.Produto.ObterProdutos)]
    public async Task<ActionResult> ObterProdutos()
    {
        return Ok(await _produtoService.ObterTodos());
    }

    [HttpGet(ApiRoutes.Produto.ObterProdutoPorId)]
    [ValidateGuid("id")]
    public async Task<ActionResult> ObterProdutoPorId(Guid id)
    {
        var produto = await _produtoService.ObterPorId(id);
        if (produto is null) return NotFound();

        return Ok(produto);
    }

    [HttpPost(ApiRoutes.Produto.NovoProduto)]
    [ValidateModel]
    public async Task<ActionResult> NovoProduto([FromBody] CriarProduto produto, CancellationToken cancellationToken)
    {
        var imagemNome = Guid.NewGuid() + "_" + produto.Imagem;
        if (!UploadArquivo(produto.ImageOnByteArrayFormat, imagemNome))
        {
            return Response(produto);
        }

        produto.Imagem = imagemNome;

        await _produtoService.Adicionar(produto, cancellationToken);

        return Response(produto);
    }

    [HttpPut(ApiRoutes.Produto.ActualizarProduto)]
    [ValidateModel]
    [Authorize(Roles ="Admin")]
    public async Task<ActionResult> ActualizarProduto([FromBody] ActualizarProduto produto, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(produto.ImageOnByteArrayFormat))
        {
            var imagemNome = Guid.NewGuid() + "_" + produto.Imagem;
            if (!UploadArquivo(produto.ImageOnByteArrayFormat, imagemNome))
            {
                return Response(produto);
            }

            produto.Imagem = imagemNome;
        }

        await _produtoService.Actualizar(produto, cancellationToken);

        return Response(produto);
    }

    [HttpDelete(ApiRoutes.Produto.RemoverProduto)]
    [ValidateGuid("id")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> RemoverProduto(Guid id, CancellationToken cancellationToken)
    {
        var produto = await _produtoService.ObterPorId(id);
        if (produto is null) return NotFound();

        await _produtoService.Remover(produto, cancellationToken);

        if (OperationIsValid()) DeleteImage(produto.Imagem);

        return Response();
    }

    private bool UploadArquivo(string arquivo, string imgNome)
    {
        if (string.IsNullOrEmpty(arquivo))
        {
            Notify("Forneça uma imagem para este produto!");
            return false;
        }

        var imageDataByteArray = Convert.FromBase64String(arquivo);

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens/produtos", imgNome);

        if (System.IO.File.Exists(filePath))
        {
            Notify("Já existe um arquivo com este nome!");
            return false;
        }

        System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

        return true;
    }

    private void DeleteImage(string imageFileName)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/produtos/" + imageFileName);

        if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
    }
}
