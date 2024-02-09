// Importando as bibliotecas System e MediatR
using System;
// Biblioteca que faz a mediação entre os projetos da aplicação permitindo a comunicação entre eles
// e o envio de mensagens
using MediatR;

// Definindo o namespace NerdStore.Core.Messages
namespace NerdStore.Core.Messages
{
    // Definindo a classe abstrata Event que herda de Message e implementa a interface INotification
    // INotification - é uma interface de marcação, ou seja, ela só indica que classe que a implementa vai entregar uma notificação
    public abstract class Event : Message, INotification
    {
        // Propriedade Timestamp do tipo DateTime. Esta propriedade é privada para set e pode ser obtida publicamente.
        // Recebe a data e a hora do evento/mensagem
        public DateTime Timestamp { get; private set; }

        // Construtor protegido da classe Event
        protected Event()
        {
            // Atribui a data e hora atuais à propriedade Timestamp
            Timestamp = DateTime.Now;
        }
    }
}
