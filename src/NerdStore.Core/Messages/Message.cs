// Importando a biblioteca System
using System;

// Definindo o namespace NerdStore.Core.Messages
namespace NerdStore.Core.Messages
{
    // Definindo a classe abstrata Message. Classes abstratas não podem ser instanciadas diretamente.
    // Classes abstratas só podem ser herdadas por outras classes que a implementam
    public abstract class Message
    {
        // Propriedade MessageType do tipo string. Esta propriedade é protegida para set e pode ser obtida publicamente.
        // Recebe o tipo da mensagem ou o nome da mensagem
        // protected - indica que a propriedade só pode ser alterada pela classe que herdar esta classe
        public string MessageType { get; protected set; }

        // Propriedade AggregateId do tipo Guid. Esta propriedade é protegida para set e pode ser obtida publicamente.
        public Guid AggregateId { get; protected set; }

        // Construtor protegido da classe Message
        protected Message()
        {
            // Atribui o nome do tipo da classe atual à propriedade MessageType
            MessageType = GetType().Name;
            // Atribui o nome da classe que está implementando esta classe (Message)
        }
    }
}
