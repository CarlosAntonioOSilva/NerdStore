using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalogo.Application.ViewModels
{
    /*************** ESTA CLASSE É COMO UMA "CÓPIA" DA ENTIDADE "PRODUTO" ***************/

    // Declara o namespace NerdStore.Catalogo.Application.ViewModels.
    public class ProdutoViewModel // Poderia se chamar "ProdutoDto" ou "ProdutoAppModel"
    {
        // Atributo de chave primária para identificar a propriedade Id.
        [Key]
        // Declara uma propriedade pública do tipo Guid chamada Id.
        public Guid Id { get; set; }

        // O {0} - representam placeholders para interpoladores de string
        // O {0} - será substituído pelo nome da propriedade associada à mensagem de erro

        // Atributo que especifica que a propriedade CategoriaId é obrigatória, com mensagem de erro personalizada.
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CategoriaId { get; set; }

        // Atributo que especifica que a propriedade Nome é obrigatória, com mensagem de erro personalizada.
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        // Atributo que especifica que a propriedade Descrição é obrigatória, com mensagem de erro personalizada.
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        // Atributo que especifica que a propriedade Ativo é obrigatória, com mensagem de erro personalizada.
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Ativo { get; set; }

        // Atributo que especifica que a propriedade Valor é obrigatória, com mensagem de erro personalizada.
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        // Atributo que especifica que a propriedade DataCadastro é obrigatória, com mensagem de erro personalizada.
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataCadastro { get; set; }

        // Atributo que especifica que a propriedade Imagem é obrigatória, com mensagem de erro personalizada.
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Imagem { get; set; }

        // "1, int.MaxValue" - indica que o valor mínimo é 1 até o valor máximo de int

        // Atributo que especifica que a propriedade QuantidadeEstoque é obrigatória e deve estar no intervalo de 1 a int.MaxValue, com mensagem de erro personalizada.
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        // Atributo que especifica que a propriedade QuantidadeEstoque é obrigatória, com mensagem de erro personalizada.
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QuantidadeEstoque { get; set; }

        // Atributo que especifica que a propriedade Altura é obrigatória e deve estar no intervalo de 1 a int.MaxValue, com mensagem de erro personalizada.
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        // Atributo que especifica que a propriedade Altura é obrigatória, com mensagem de erro personalizada.
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Altura { get; set; }

        // Atributo que especifica que a propriedade Largura é obrigatória e deve estar no intervalo de 1 a int.MaxValue, com mensagem de erro personalizada.
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        // Atributo que especifica que a propriedade Largura é obrigatória, com mensagem de erro personalizada.
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Largura { get; set; }

        // Atributo que especifica que a propriedade Profundidade é obrigatória e deve estar no intervalo de 1 a int.MaxValue, com mensagem de erro personalizada.
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        // Atributo que especifica que a propriedade Profundidade é obrigatória, com mensagem de erro personalizada.
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Profundidade { get; set; }

        // Declara uma propriedade pública do tipo IEnumerable<CategoriaViewModel> chamada Categorias.
        public IEnumerable<CategoriaViewModel> Categorias { get; set; }
    }
}
