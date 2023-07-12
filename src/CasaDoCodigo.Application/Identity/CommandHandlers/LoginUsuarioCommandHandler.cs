using Microsoft.AspNetCore.Identity;

namespace CasaDoCodigo.Application.Identity.CommandHandlers;

public class LoginUsuarioCommandHandler : IRequestHandler<LoginUsuarioCommand, IdentityUserResponse>
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IJwtService _jwtService;
    private readonly INotifier _notifier;
    public LoginUsuarioCommandHandler(SignInManager<IdentityUser> signInManager,
                                      IJwtService jwtService,
                                      INotifier notifier,
                                      UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _jwtService = jwtService;
        _notifier = notifier;
        _userManager = userManager;
    }

    public async Task<IdentityUserResponse> Handle(LoginUsuarioCommand command, CancellationToken cancellationToken)
    {
        if (!ValidateCommand(command)) return null;

        var identityUser = await _userManager.FindByEmailAsync(command.Email);
        if(identityUser is null)
        {
            _notifier.Handle(new Notification(IdentityErrorMessages.IncorrectUserNameOrPassword));
            return null;
        }

        var signInResult = await _signInManager.CheckPasswordSignInAsync(identityUser, command.Senha, true);

        if(signInResult.IsLockedOut)
        {
            _notifier.Handle(new Notification(IdentityErrorMessages.LockoutOnFailure));
            return null;
        }

        if(!signInResult.Succeeded)
        {
            _notifier.Handle(new Notification(IdentityErrorMessages.IncorrectUserNameOrPassword));
            return null;
        }

        return new IdentityUserResponse
        {
            UserName = command.Email,
            Email = command.Email,
            Token = await _jwtService.GetJwtString(identityUser)
        };
    }

    private bool ValidateCommand(LoginUsuarioCommand command)
    {
        if (command.IsValid()) return true;

        foreach (var error in command.ValidationResult.Errors)
        {
            _notifier.Handle(new Notification(error.ErrorMessage));
        }

        return false;
    }
}
