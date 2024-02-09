// Importando as bibliotecas necessárias
using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;

// Definindo o namespace
namespace NerdStore.Catalogo.Data.Repository
{
    // Definindo a classe ProdutoRepository que implementa a interface IProdutoRepository
    public class ProdutoRepository : IProdutoRepository
    {
        // Declaração de uma variável privada para o contexto do banco de dados
        private readonly CatalogoContext _context; // Recebe a classe de contexto do EF

        // Construtor que recebe o contexto do banco de dados como parâmetro
        public ProdutoRepository(CatalogoContext context)
        {
            _context = context; // Atribuindo o contexto recebido à variável privada _context
        }

        // Propriedade que retorna o contexto do banco de dados como uma unidade de trabalho
        // Indica que "IUnitOfWork" reflete o contexto  "_context"
        public IUnitOfWork UnitOfWork => _context;

        // Método para obter todos os produtos
        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            // Retorna todos os produtos do banco de dados sem rastreamento
            return await _context.Produtos.AsNoTracking().ToListAsync();

            // AsNoTracking para desabilitar o rastreamento de mudanças e melhorar o desempenho.
        }

        // Método para obter um produto por ID
        public async Task<Produto> ObterPorId(Guid id)
        {
            // Retorna o produto com o ID especificado sem rastreamento
            return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            // O método FirstOrDefaultAsync está sendo usado para buscar o primeiro produto que
            // corresponde à condição p => p.Id == id

            // A variável p se torna uma instância de Produto devido ao contexto em que a expressão
            // lambda p => p.Id == id é usada. No caso do método FirstOrDefaultAsync, ele é usado
            // para operar em um DbSet<Produto>.
        }

        // Método para obter produtos por categoria
        public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        {
            // _context.Produtos.AsNoTracking() - Inicia uma consulta ao conjunto de produtos no banco de dados, desativa o rastreamento de alterações,
            // Include(p => p.Categoria) - carrega os dados relacionados da tabela Categoria para cada produto (carregamento antecipado),
            // Where(c => c.Categoria.Codigo == codigo) - filtra a consulta para incluir apenas os produtos cujo código de categoria corresponda ao código fornecido,
            // ToListAsync() - executa a consulta e retorna os resultados como uma lista de forma assíncrona.
            return await _context.Produtos.AsNoTracking().Include(p => p.Categoria).Where(c => c.Categoria.Codigo == codigo).ToListAsync();
        }

        // Método para obter todas as categorias
        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            // Retorna todas as categorias do banco de dados sem rastreamento
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }

        // Método para adicionar um produto
        public void Adicionar(Produto produto)
        {
            // Adiciona o produto ao contexto do banco de dados
            _context.Produtos.Add(produto);
        }

        // Método para atualizar um produto
        public void Atualizar(Produto produto)
        {
            // Atualiza o produto no contexto do banco de dados
            _context.Produtos.Update(produto);
        }

        // Método para adicionar uma categoria
        public void Adicionar(Categoria categoria)
        {
            // Adiciona a categoria ao contexto do banco de dados
            _context.Categorias.Add(categoria);
        }

        // Método para atualizar uma categoria
        public void Atualizar(Categoria categoria)
        {
            // Atualiza a categoria no contexto do banco de dados
            _context.Categorias.Update(categoria);
        }

        // Método para liberar os recursos do contexto do banco de dados
        public void Dispose()
        {
            // Libera os recursos do contexto do banco de dados
            _context?.Dispose();
        }
    }
}
