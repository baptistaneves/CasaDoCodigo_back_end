namespace CasaDoCodigo.Infrastructure.Identity.Services;

public interface IJwtService
{
    Task<string> GetJwtString(IdentityUser identityUser);
}
