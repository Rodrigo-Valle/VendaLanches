using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaLanches.Models;

[Table("Lanches")]
public class Lanche
{
    [Key]
    public int LancheId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Nome do Lanche")]
    [StringLength(80, MinimumLength = 10, ErrorMessage = "O campo {0} deve ter no minimo {1} e no máximo {2} caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Descricao Curta")]
    [StringLength(200, MinimumLength = 20, ErrorMessage = "O campo {0} deve ter no minimo {1} e no máximo {2} caracteres")]
    public string DescricaoCurta { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Descricao Longa")]
    [StringLength(400, MinimumLength = 20, ErrorMessage = "O campo {0} deve ter no minimo {1} e no máximo {2} caracteres")]
    public string DescricaoLonga { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Preço")]
    [Column(TypeName = "decimal(10,2)")]
    [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999.99")]
    public decimal Preco { get; set; }

    [Display(Name = "Caminho Imagem")]
    public string ImagemURL { get; set; }

    [Display(Name = "Caminho Thumb")]
    public string ImagemThumbnailURL { get; set; }

    [Display(Name = "Preferido?")]
    public bool LanchePreferido { get; set; }

    [Display(Name = "Estoque?")]
    public bool Estoque { get; set; }

    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
}