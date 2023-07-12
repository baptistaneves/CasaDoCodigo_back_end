namespace CasaDoCodigo.API.Registrars;

public class DependecyInjectionRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        //Infrastructure
        builder.Services.AddScoped<ApplicationDbContext>();

        //Notifications
        builder.Services.AddScoped<INotifier, Notifier>();

        //Jwt Service
        builder.Services.AddScoped<IJwtService, JwtService>();

        //Application Layer
        builder.Services.ConfigureApplication(builder.Configuration);

        //Categorias
        builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        builder.Services.AddScoped<ICategoriaService, CategoriaService>();

        //Produtos
        builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
        builder.Services.AddScoped<IProdutoService, ProdutoService>();
    }
}
