namespace CasaDoCodigo.Application.Identity.CommandHandlers;

public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, IdentityUserResponse>
{
    private readonly IJwtService _jwtService;
    private readonly INotifier _notifier;
    private readonly UserManager<IdentityUser> _userManager;
    public CriarUsuarioCommandHandler(IJwtService jwtService,
                                      UserManager<IdentityUser> userManager,
                                      INotifier notifier)
    {
        _jwtService = jwtService;
        _userManager = userManager;
        _notifier = notifier;
    }

    public async Task<IdentityUserResponse> Handle(CriarUsuarioCommand command, CancellationToken cancellationToken)
    {
        if (!ValidateCommand(command)) return null;

        var identity = new IdentityUser { UserName = command.Email, Email = command.Email };
        var createResult = await _userManager.CreateAsync(identity, command.Senha);

        if(createResult.Succeeded)
        {
            var addToRoleResult = await _userManager.AddToRoleAsync(identity, command.Perfil);
            if(!addToRoleResult.Succeeded) 
            {
                foreach (var error in addToRoleResult.Errors)
                {
                    _notifier.Handle(new Notification(error.Description));
                }

                return null;
            }

            return new IdentityUserResponse
            {
                UserName = command.Email,
                Email = command.Email,
                Token = await _jwtService.GetJwtString(identity)
            };
        }

        foreach(var error in createResult.Errors)
        {
            _notifier.Handle(new Notification(error.Description));
        }

        return null;
    }

    private bool ValidateCommand(CriarUsuarioCommand command)
    {
        if (command.IsValid()) return true;

        foreach (var error in command.ValidationResult.Errors)
        {
            _notifier.Handle(new Notification(error.ErrorMessage));
        }

        return false;
    }
}
