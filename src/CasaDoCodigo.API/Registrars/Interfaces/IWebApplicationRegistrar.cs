namespace CasaDoCodigo.API.Registrars.Interfaces;

public interface IWebApplicationRegistrar : IRegistrar
{
    void RegisterServices(WebApplication app);
}
