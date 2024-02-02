using System; // Importa o namespace System, que contém classes fundamentais e base para o desenvolvimento de aplicativos em C#.
using NerdStore.Core.DomainObjects; // Importa o namespace NerdStore.Core.DomainObjects, que contém definições básicas de domínio.

namespace NerdStore.Catalogo.Domain
{
    // Declaração de uma classe Produto que herda da classe Entity e implementa a interface IAggregateRoot.
    // IAggregateRoot - interface de marcação utilizada para indicar se um classe é uma "entidade" ou uma "raiz de agregação"
    public class Produto : Entity, IAggregateRoot 
    {
        // Declaração das propriedades da classe Produto.
        public Guid CategoriaId { get; private set; } // Id da entidade "Categoria" no banco de dados
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Dimensoes Dimensoes { get; private set; } // Recebe as dimensões do produto
        public Categoria Categoria { get; private set; } // Recebe a categoria do produto

        // Construtor protegido da classe Produto.
        protected Produto() { }

        // Construtor da classe Produto que recebe parâmetros para inicializar as propriedades.
        public Produto(string nome, string descricao, bool ativo, decimal valor, Guid categoriaId, DateTime dataCadastro, string imagem, Dimensoes dimensoes)
        {
            // Inicialização das propriedades com os valores dos parâmetros.
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            Dimensoes = dimensoes;

            // Chama o método Validar para garantir que o objeto Produto está em um estado válido.
            Validar();
        }

        // Este método define o estado do produto como ativo, atribuindo o valor true à propriedade Ativo.
        public void Ativar() => Ativo = true;

        // Este método define o estado do produto como inativo, atribuindo o valor false à propriedade Ativo.
        public void Desativar() => Ativo = false;

        // Método para alterar a categoria do produto.
        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria; // Altera a categoria
            CategoriaId = categoria.Id; // Altera o id da categoria
        }

        // Método para alterar a descrição do produto.
        public void AlterarDescricao(string descricao)
        {
            // Verifica se a descrição não está vazia e lança uma exceção se estiver.
            Validacoes.ValidarSeVazio(descricao, "O campo Descricao do produto não pode estar vazio");
            Descricao = descricao;
        }

        // Método para debitar o estoque do produto.
        public void DebitarEstoque(int quantidade)
        {
            // Verifica se a quantidade é negativa e a torna positiva.
            if (quantidade < 0) quantidade *= -1;

            // Verifica se há estoque suficiente e lança uma exceção se não houver.
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");

            // Reduz a quantidade em estoque.
            QuantidadeEstoque -= quantidade;
        }

        // Método para repor o estoque do produto.
        public void ReporEstoque(int quantidade)
        {
            // Aumenta a quantidade em estoque.
            QuantidadeEstoque += quantidade;
        }

        // Método para verificar se o produto possui estoque suficiente.
        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        // Método para validar se o objeto Produto está em um estado válido.
        public void Validar()
        {
            // Validações de propriedades do Produto.
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(Descricao, "O campo Descricao do produto não pode estar vazio");
            Validacoes.ValidarSeIgual(CategoriaId, Guid.Empty, "O campo CategoriaId do produto não pode estar vazio");
            Validacoes.ValidarSeMenorQue(Valor, 1, "O campo Valor do produto não pode se menor igual a 0");
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode estar vazio");
        }
    }
}
