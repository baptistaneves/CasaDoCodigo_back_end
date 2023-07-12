namespace CasaDoCodigo.API.Registrars.Interfaces;

public interface IWebApplicationBuilderRegistrar : IRegistrar
{
    void RegisterServices(WebApplicationBuilder builder);
}
