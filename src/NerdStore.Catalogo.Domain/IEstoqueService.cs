// Define o namespace NerdStore.Catalogo.Domain
namespace NerdStore.Catalogo.Domain
{
    // Define a interface IEstoqueService que herda de IDisposable
    // A interface IDisposable é usada em C# para fornecer um mecanismo
    // para liberar recursos não gerenciados
    public interface IEstoqueService : IDisposable
    {
        // Declaração do método DebitarEstoque que recebe um Guid representando o
        // ID do produto e um inteiro representando a quantidade.
        // Este método é assíncrono e retorna uma Task que encapsula um booleano.
        // O booleano indica se a operação foi bem-sucedida.
        Task<bool> DebitarEstoque(Guid produtoId, int quantidade);

        // Declaração do método ReporEstoque que recebe um Guid representando o
        // ID do produto e um inteiro representando a quantidade.
        // Este método é assíncrono e retorna uma Task que encapsula um booleano.
        // O booleano indica se a operação foi bem-sucedida.
        Task<bool> ReporEstoque(Guid produtoId, int quantidade);
    }
}
