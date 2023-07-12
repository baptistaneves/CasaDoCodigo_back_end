using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Application.Contracts.Produtos.Requests;

public class CriarProduto
{
    [Required(ErrorMessage = "O Titulo deve ser informado")]
    [MinLength(4, ErrorMessage = "O Titulo deve ter no minímo 4 caracteres")]
    public string Titulo { get; set; }

    public string? Descricao { get; set; }

    [Required(ErrorMessage = "Selecione uma Imagem para o produto")]
    public string Imagem { get; set; }

    public string? ImageOnByteArrayFormat { get; set; }

    public Guid CategoriaId { get; set; }
}


public class ActualizarProduto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O Titulo deve ser informado")]
    [MinLength(4, ErrorMessage = "O Titulo deve ter no minímo 4 caracteres")]
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public string? Imagem { get; set; }
    public string? ImageOnByteArrayFormat { get; set; }
    public Guid CategoriaId { get; set; }
}