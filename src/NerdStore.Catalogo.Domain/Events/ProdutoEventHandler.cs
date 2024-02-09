// Importa o namespace do MediatR, que é uma biblioteca de mensagens e notificações para aplicações .NET.
using MediatR;

// Declaração de namespace para o escopo do código.
namespace NerdStore.Catalogo.Domain.Events 
{
    // Declaração de uma classe chamada ProdutoEventHandler que implementa a interface INotificationHandler com
    // o tipo de evento ProdutoAbaixoEstoqueEvent.
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent> 
    {
        // Declaração de uma variável privada somente leitura do tipo IProdutoRepository.
        private readonly IProdutoRepository _produtoRepository;

        // Construtor da classe ProdutoEventHandler que recebe uma instância de IProdutoRepository como parâmetro.
        public ProdutoEventHandler(IProdutoRepository produtoRepository) 
        {
            // Atribuição do parâmetro produtoRepository à variável _produtoRepository.
            _produtoRepository = produtoRepository; 
        }

        // Comentário: Enviar um email para aquisicao de mais produtos.

        // Declaração de um método assíncrono chamado Handle que recebe um ProdutoAbaixoEstoqueEvent como mensagem
        // e um CancellationToken como parâmetro.
        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken) 
        {
            // Declaração de uma variável produto que recebe o resultado da chamada assíncrona do método
            // ObterPorId do _produtoRepository, passando o AggregateId da mensagem como parâmetro.
            var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId); 

        }
    }
}
