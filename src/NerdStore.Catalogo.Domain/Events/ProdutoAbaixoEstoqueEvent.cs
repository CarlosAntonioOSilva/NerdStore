// Importando as bibliotecas System e NerdStore.Core.DomainObjects
using NerdStore.Core.DomainObjects;

// Definindo o namespace NerdStore.Catalogo.Domain.Events
namespace NerdStore.Catalogo.Domain.Events
{
    // Definindo a classe ProdutoAbaixoEstoqueEvent que herda de DomainEvent
    public class ProdutoAbaixoEstoqueEvent : DomainEvent
    {
        // Propriedade QuantidadeRestante do tipo int. Esta propriedade é privada para set e pode ser obtida publicamente.
        // Recebe a quantidade restante do estoque
        public int QuantidadeRestante { get; private set; }

        // Construtor da classe ProdutoAbaixoEstoqueEvent que recebe um Guid representando o ID do agregado e um inteiro representando a quantidade restante
        public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante) : base(aggregateId)
        {
            // Atribui a quantidade restante recebida à propriedade QuantidadeRestante
            QuantidadeRestante = quantidadeRestante;
        }
    }
}
