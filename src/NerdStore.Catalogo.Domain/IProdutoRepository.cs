using NerdStore.Core.Data; // Importa o namespace NerdStore.Core.Data, que contém definições básicas de acesso a dados.

// Interface específica de repositório para entidade "Produto"
namespace NerdStore.Catalogo.Domain
{
    // Herda a interface genérica de repositório "IRepository"
    public interface IProdutoRepository : IRepository<Produto>
    {
        // Declaração de métodos para operações específicas de Produto no repositório.

        // Método para obter todos os produtos.
        // Declara um método assíncrono que retorna uma coleção de todos os produtos.
        Task<IEnumerable<Produto>> ObterTodos();

        // Método para obter um produto por ID.
        // Declara um método assíncrono que retorna um produto com base no ID fornecido.
        Task<Produto> ObterPorId(Guid id);

        // Método para obter produtos por categoria.
        // Declara um método assíncrono que retorna uma coleção de produtos com base no código da categoria fornecido.
        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);

        // Método para obter todas as categorias.
        // Declara um método assíncrono que retorna uma coleção de todas as categorias.
        Task<IEnumerable<Categoria>> ObterCategorias();

        // Métodos para adicionar e atualizar produtos.
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);

        // Métodos para adicionar e atualizar categorias.
        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
    }
}
