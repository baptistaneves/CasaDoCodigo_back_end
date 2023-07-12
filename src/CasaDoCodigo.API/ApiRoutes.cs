namespace CasaDoCodigo.API;

public class ApiRoutes
{
    public const string BaseRoute = "api/v{version:apiVersion}/[controller]";

    public static class Usuario
    {
        public const string CriarUsuario = "criar-usuario";
        public const string Login = "login";
        public const string ObterUsuarios = "obter-usuarios";
        public const string ObterUsuarioPorId = "obter-usuario-por-id/{id}";
    }

    public static class Categoria
    {
        public const string ObterCategorias = "obter-categorias";
        public const string ObterCategoriaPorId = "obter-categoria-por-id/{id}";
        public const string NovaCategoria = "nova-categoria";
        public const string ActualizarCategoria = "actualizar-categoria";
        public const string RemoverCategoria = "remover-categoria/{id}";
    }

    public static class Produto
    {
        public const string ObterProdutos = "obter-produtos";
        public const string ObterProdutoPorId = "obter-produto-por-id/{id}";
        public const string NovoProduto = "novo-produto";
        public const string ActualizarProduto = "actualizar-produto";
        public const string RemoverProduto = "remover-produto/{id}";
    }
}
