// Importando as bibliotecas MediatR e NerdStore.Core.Messages
using MediatR;
using NerdStore.Core.Messages;

// Definindo o namespace NerdStore.Core.Bus
namespace NerdStore.Core.Bus
{
    // Definindo a classe MediatrHandler que implementa a interface IMediatrHandler
    public class MediatrHandler : IMediatrHandler
    {
        // Declaração de uma variável privada para o mediador
        private readonly IMediator _mediator;

        // Construtor que recebe o mediador como parâmetro
        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator; // Atribuindo o mediador recebido à variável privada _mediator
        }

        // Método da interface "IMediatrHandler" para publicar um evento
        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            // Publica o evento usando o mediador
            await _mediator.Publish(evento);
        }
    }
}
