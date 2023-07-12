namespace CasaDoCodigo.Domain.Produtos;

public class Produto : Entity
{
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public string Imagem { get; private set; }
    public Guid CategoriaId { get; private set; }

    public Produto(string titulo, string descricao, string imagem, Guid categoriaId)
    {
        Titulo = titulo;
        Descricao = descricao;
        Imagem = imagem;
        CategoriaId = categoriaId;
    }

    //For EF
    public Categoria Categoria { get; private set; }

    public void Actualizar(string titulo, string descricao, string imagem, Guid categoriaId)
    {
        Titulo = titulo;
        Descricao = descricao;
        Imagem = imagem;
        CategoriaId = categoriaId;
    }
}
