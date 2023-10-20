using System.ComponentModel.DataAnnotations;
using Projeto.Models;

namespace PROJETO.Models
{
    public class Item
    {
        public int ItemId {get; set;}
        [Display(Name = "Nome do item")]
        [Required(ErrorMessage ="Informe o nome do item")]
        [MinLength(4, ErrorMessage ="Nome deve ter no mínimo {1} caracteres")]
        [MaxLength(30, ErrorMessage ="Nome deve ter no maximo {1} caracteres")]
        public string Nome {get; set;}
        [Display(Name = "Descrição curta")]
        [Required(ErrorMessage ="Informe a descrição curta")]
        [MinLength(4, ErrorMessage ="Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage ="Descrição deve ter no maximo {1} caracteres")]
        public string DescricaoCurta {get; set;}
        [Display(Name = "Descrição Detalhada")]
        [Required(ErrorMessage ="Informe a descrição detalhada")]
        [MinLength(20, ErrorMessage ="Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage ="Descrição deve ter no maximo {1} caracteres")]
        public string DescricaoDetalhada {get; set;}
        [Display(Name = "Preço")]
        [Required(ErrorMessage ="Informe o preço")]
        public double Preco {get; set;}
        [Display(Name ="Imagem Pequena")]
        public string ImagemPequenaUrl {get; set;}
        [Display(Name ="Imagem Normal")]
        public string ImagemUrl {get; set;}
        public bool Destaque {get; set;}
        [Display(Name ="Categoria")]
        public int CategoriaId {get; set;}
        public virtual Categoria Categoria {get; set;}
    }
}