using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Application.Contracts.Categorias.Requests;

public class CriarCategoria
{
    [Required(ErrorMessage = "A Descrição deve ser informada")]
    [MinLength(4, ErrorMessage = "A Descrição deve ter no minímo 4 caracteres")]
    public string Descricao { get; set; }
}

public class ActualizarCategoria
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "A Descrição deve ser informada")]
    [MinLength(4, ErrorMessage = "A Descrição deve ter no minímo 4 caracteres")]
    public string Descricao { get; set; }
}