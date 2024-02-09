// Importando as bibliotecas necessárias
using NerdStore.Core.Bus;
using System;
using System.Threading.Tasks;
using NerdStore.Catalogo.Domain.Events;

// Definindo o namespace NerdStore.Catalogo.Domain
namespace NerdStore.Catalogo.Domain
{
    // Definindo a classe EstoqueService que implementa a interface IEstoqueService
    public class EstoqueService : IEstoqueService
    {
        // Declaração de uma variável privada para o repositório de produtos e uma para o manipulador de eventos
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatrHandler _bus;

        // Construtor que recebe o repositório de produtos e o manipulador de eventos como parâmetros
        public EstoqueService(IProdutoRepository produtoRepository, IMediatrHandler bus)
        {
            // Atribuindo o repositório de produtos recebido à variável privada _produtoRepository
            _produtoRepository = produtoRepository;
            // Atribuindo o manipulador de eventos recebido à variável privada _bus
            _bus = bus; 
        }

        // Método para debitar estoque de um produto
        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            // Obtém o produto pelo ID
            var produto = await _produtoRepository.ObterPorId(produtoId);

            // Se o produto não existir, retorna falso
            if (produto == null) return false;

            // Se o produto não tiver estoque suficiente, retorna falso
            if (!produto.PossuiEstoque(quantidade)) return false;

            // Debita a quantidade do estoque do produto
            produto.DebitarEstoque(quantidade);

            // Se a quantidade de estoque do produto for menor que 10, publica um evento ProdutoAbaixoEstoqueEvent
            if (produto.QuantidadeEstoque < 10)
            {
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }

            // Atualiza o produto no repositório
            _produtoRepository.Atualizar(produto);
            // Salva as alterações no repositório e retorna verdadeiro se houver mais de 0 alterações
            return await _produtoRepository.UnitOfWork.Commit();
        }

        // Método para repor estoque de um produto
        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            // Obtém o produto pelo ID
            var produto = await _produtoRepository.ObterPorId(produtoId);

            // Se o produto não existir, retorna falso
            if (produto == null) return false;
            // Repõe a quantidade do estoque do produto
            produto.ReporEstoque(quantidade);

            // Atualiza o produto no repositório
            _produtoRepository.Atualizar(produto);
            // Salva as alterações no repositório e retorna verdadeiro se houver mais de 0 alterações
            return await _produtoRepository.UnitOfWork.Commit();
        }

        // Método para liberar os recursos do repositório de produtos
        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
