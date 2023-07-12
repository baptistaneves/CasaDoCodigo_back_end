namespace CasaDoCodigo.Domain.Categorias;

public class Categoria : Entity
{
    public string Descricao { get; private set; }

    public Categoria(string descricao)
    {
        Descricao = descricao;
    }

    //For EF
    public IEnumerable<Produto> Produtos { get; set; }

    public void Actualizar(string descricao)
    {
        Descricao = descricao;
    }
}
