namespace CasaDoCodigo.Application.Identity.Queries;

public class ObterUsuarioPorIdQuery : IRequest<IdentityUser>
{
    public Guid Id { get; set; }
}