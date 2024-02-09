// Importa o namespace System.ComponentModel.DataAnnotations, que contém atributos de validação de dados.
using System.ComponentModel.DataAnnotations;

// Declara o namespace NerdStore.Catalogo.Application.ViewModels.
namespace NerdStore.Catalogo.Application.ViewModels 
{
    // Declara uma classe pública chamada CategoriaViewModel.
    public class CategoriaViewModel
    {
        // Atributo de chave primária para identificar a propriedade Id.
        [Key]
        // Declara uma propriedade pública do tipo Guid chamada Id.
        public Guid Id { get; set; }

        // Atributo que especifica que a propriedade Nome é obrigatória, com mensagem de erro personalizada.
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        // Declara uma propriedade pública do tipo string chamada Nome.
        public string Nome { get; set; }

        // Atributo que especifica que a propriedade Codigo é obrigatória, com mensagem de erro personalizada.
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        // Declara uma propriedade pública do tipo int chamada Codigo.
        public int Codigo { get; set; }
    }
}
