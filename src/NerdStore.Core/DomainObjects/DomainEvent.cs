// Importando as bibliotecas System e NerdStore.Core.Messages
using System;
using NerdStore.Core.Messages;

// Definindo o namespace NerdStore.Core.DomainObjects
namespace NerdStore.Core.DomainObjects
{
    // Definindo a classe DomainEvent que herda de Event
    public class DomainEvent : Event
    {
        // Construtor da classe DomainEvent que recebe um Guid representando o ID do agregado
        public DomainEvent(Guid aggregateId)
        {
            // Atribui o ID do agregado recebido à propriedade AggregateId da classe base
            AggregateId = aggregateId;
        }
    }
}
