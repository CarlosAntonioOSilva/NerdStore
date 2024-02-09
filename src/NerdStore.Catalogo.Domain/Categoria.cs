using System.Collections.Generic;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        // ATENÇÃO: Esta entidade está recebendo o número de ID da classe "Entity"

        public string Nome { get; private set; } // recebe o nome da categoria
        public int Codigo { get; private set; } // recebe o código da categoria

        // Indica o relacinamento entre categorias e produtos, necessário para implementação do mapeamento
        // "CategoriaMapping" requerido para utilização do EF
        public ICollection<Produto> Produtos { get; set; } // recebe uma coleção de produtos associados à categoria

        // O construtor sem parâmetro é necessário porque o EF tem problemas em popular objetos que
        // não tenham o construtor aberto (sem parâmetros)
        protected Categoria() { }

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode ser 0");
        }
    }
}