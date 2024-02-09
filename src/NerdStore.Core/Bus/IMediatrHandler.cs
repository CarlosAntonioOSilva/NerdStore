/* INTERFACE PARA CONFIGURAÇÃO DA FERRAMENTA "MEDIATR"*/


// Importando a biblioteca NerdStore.Core.Messages
using NerdStore.Core.Messages;

// Definindo o namespace NerdStore.Core.Bus
namespace NerdStore.Core.Bus
{
    // Definindo a interface IMediatrHandler
    public interface IMediatrHandler
    {
        // Declaração do método PublicarEvento que recebe um parâmetro genérico 'evento' do tipo Event.
        // Este método é assíncrono e retorna uma Task.
        // A restrição 'where T : Event' indica que o tipo genérico T deve ser ou herdar de Event.
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}
