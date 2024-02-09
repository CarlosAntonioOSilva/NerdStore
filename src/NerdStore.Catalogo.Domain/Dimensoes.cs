// Importa o namespace NerdStore.Core.DomainObjects para uso neste arquivo.
using NerdStore.Core.DomainObjects;

// Declara um namespace chamado NerdStore.Catalogo.Domain.
namespace NerdStore.Catalogo.Domain
{
    // Declara uma classe pública chamada Dimensoes.
    public class Dimensoes
    {
        // Declara três propriedades públicas de tipo decimal: Altura, Largura e Profundidade. Elas só podem ser definidas dentro desta classe (private set).
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        // Declara um construtor público para a classe Dimensoes que aceita três parâmetros decimais: altura, largura e profundidade.
        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            // Valida se a altura, largura e profundidade são menores que 1. Se forem, uma exceção é lançada.
            Validacoes.ValidarSeMenorQue(altura, 1, "O campo Altura não pode ser menor ou igual a 0");
            Validacoes.ValidarSeMenorQue(largura, 1, "O campo Largura não pode ser menor ou igual a 0");
            Validacoes.ValidarSeMenorQue(profundidade, 1, "O campo Profundidade não pode ser menor ou igual a 0");

            // Atribui os valores dos parâmetros às propriedades correspondentes.
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        // Declara um método público que retorna uma string formatada com as dimensões.
        public string DescricaoFormatada()
        {
            // Retorna uma string formatada com as dimensões no formato "LxAxP: Largura x Altura x Profundidade".
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        // Sobrescreve o método ToString() para retornar a descrição formatada das dimensões.
        public override string ToString()
        {
            // Retorna a descrição formatada das dimensões.
            return DescricaoFormatada();
        }
    }
}
