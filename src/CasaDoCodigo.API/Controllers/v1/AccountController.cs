namespace CasaDoCodigo.API.Controllers.v1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
public class AccountController : BaseController
{
    private readonly IMediator _mediator;
    public AccountController(INotifier notifier, IMediator mediator) : base(notifier)
    {
        _mediator = mediator;
    }

    [HttpGet(ApiRoutes.Usuario.ObterUsuarios)]
    public async Task<ActionResult> ObterUsuarios(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new ObterTodosUsuariosQuery { }, cancellationToken));
    }

    [HttpGet(ApiRoutes.Usuario.ObterUsuarioPorId)]
    [ValidateGuid("id")]
    public async Task<ActionResult> ObterUsuarioPorId(Guid id, CancellationToken cancellationToken)
    {
        var usuario = await _mediator.Send(new ObterUsuarioPorIdQuery { Id = id }, cancellationToken);
        return Response(usuario);
    }

    [HttpPost(ApiRoutes.Usuario.CriarUsuario)]
    [ValidateModel]
    public async Task<ActionResult> CriarUsuario([FromBody] CriarUsuario usuario, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CriarUsuarioCommand(usuario.Email, usuario.Senha, usuario.Perfil), cancellationToken);
        return Response(result);
    }

    [HttpPost(ApiRoutes.Usuario.Login)]
    [ValidateModel]
    public async Task<ActionResult> Login([FromBody] LoginUsuario login, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new LoginUsuarioCommand(login.Email, login.Senha), cancellationToken);
        return Response(result);
    }
}
