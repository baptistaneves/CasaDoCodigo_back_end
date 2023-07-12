namespace CasaDoCodigo.Application.Identity.QueryHandler;

public class ObterTodosUsuariosQueryHandler : IRequestHandler<ObterTodosUsuariosQuery, List<IdentityUser>>
{
    private readonly ApplicationDbContext _context;

    public ObterTodosUsuariosQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<IdentityUser>> Handle(ObterTodosUsuariosQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users.ToListAsync(cancellationToken);
    }
}
