namespace CasaDoCodigo.API.Controllers.v1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
[Authorize]
public class CategoriasController : BaseController
{
    private readonly ICategoriaService _categoriaService;
    public CategoriasController(INotifier notifier, ICategoriaService categoriaService) : base(notifier)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet(ApiRoutes.Categoria.ObterCategorias)]
    public async Task<ActionResult> ObterCategorias()
    {
        return Ok(await _categoriaService.ObterTodos());
    }

    [HttpGet(ApiRoutes.Categoria.ObterCategoriaPorId)]
    [ValidateGuid("id")]
    public async Task<ActionResult> ObterCategoriaPorId(Guid id)
    {
        var categoria = await _categoriaService.ObterPorId(id);
        if (categoria is null) return NotFound();

        return Ok(categoria);
    }

    [HttpPost(ApiRoutes.Categoria.NovaCategoria)]
    [ValidateModel]
    public async Task<ActionResult> NovaCategoria([FromBody] CriarCategoria categoria, CancellationToken cancellationToken)
    {
        await _categoriaService.Adicionar(categoria, cancellationToken);

        return Response(categoria);
    }

    [HttpPut(ApiRoutes.Categoria.ActualizarCategoria)]
    [ValidateModel]
    public async Task<ActionResult> ActualizarCategoria([FromBody] ActualizarCategoria categoria, CancellationToken cancellationToken)
    {
        await _categoriaService.Actualizar(categoria, cancellationToken);

        return Response(categoria);
    }

    [HttpDelete(ApiRoutes.Categoria.RemoverCategoria)]
    [ValidateGuid("id")]
    public async Task<ActionResult> RemoverCategoria(Guid id, CancellationToken cancellationToken)
    {
        var categoria = await _categoriaService.ObterPorId(id);
        if (categoria is null) return NotFound();

        await _categoriaService.Remover(categoria, cancellationToken);

        return Response();
    }
}
