using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APICatalogo.Validations;

namespace APICatalogo.DTOs;

public class ProdutoDTO
{
    public int ProdutoId {get; set;}
    
    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    [StringLength(80)]
    [PrimeiraLetraMaiuscula]
    public string? Nome {get; set;}

    [Required(ErrorMessage = "A descrição do produto é obrigatória")]
    [StringLength(300)]
    public string? Descricao {get; set;}

    [Required]
    public decimal Preco {get; set;}

    [Required]
    [StringLength(300)]
    public string? ImagemUrl {get; set;}
    public int CategoriaId{get; set;}
}