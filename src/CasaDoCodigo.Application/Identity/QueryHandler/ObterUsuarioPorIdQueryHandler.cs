namespace CasaDoCodigo.Application.Identity.QueryHandler;

public class ObterUsuarioPorIdQueryHandler : IRequestHandler<ObterUsuarioPorIdQuery, IdentityUser>
{
    private readonly ApplicationDbContext _context;
    private readonly INotifier _noifier;

    public ObterUsuarioPorIdQueryHandler(ApplicationDbContext context, 
                                         INotifier noifier)
    {
        _context = context;
        _noifier = noifier;
    }

    public async Task<IdentityUser> Handle(ObterUsuarioPorIdQuery request, CancellationToken cancellationToken)
    {
        var identityUser = await _context.Users
            .AsNoTracking().FirstOrDefaultAsync(u => u.Id == request.Id.ToString());

        if(identityUser == null)
        {
            _noifier.Handle(new Notification(IdentityErrorMessages.IdentityUserNotFound));
            return null;
        }

        return identityUser;   
    }
}
