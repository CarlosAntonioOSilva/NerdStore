using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;

namespace NerdStore.Catalogo.Data
{
    // Definição da classe CatalogoContext, que herda de DbContext e implementa IUnitOfWork
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        /*
         - DbContext é a principal classe que coordena a funcionalidade do Entity Framework para um modelo de dados
         - IUnitOfWork é uma interface que encapsula tudo que pode ser feito com o DbContext em termos de persistência de dados.
         
         */

        // Construtor da classe que recebe DbContextOptions<CatalogoContext> como parâmetro
        public CatalogoContext(DbContextOptions<CatalogoContext> options)
            : base(options) { }

        // Declaração dos DbSets para as entidades Produto e Categoria
        /*
            DbSet<Produto> e DbSet<Categoria> são propriedades que representam coleções de entidades 
            Produto e Categoria que podem ser consultadas a partir do banco de dados.
        */
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        // Sobrescreve o método OnModelCreating para configurar o modelo de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura o tipo de coluna para todas as propriedades do tipo string como varchar(100)
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            // Aplica as configurações de mapeamento de entidades a partir do assembly que contém a classe CatalogoContext
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
            // Busca todas as entidades mapeadas por "DbSet" e os "Mappings"
        }

        // Implementação do método Commit da interface IUnitOfWork
        public async Task<bool> Commit() // Serve para salvar no banco
        {
            // Itera sobre todas as entidades rastreadas pelo ChangeTracker
            // O Where filtra as entidades que possuem uma propriedade chamada
            // "DataCadastro", provavelmente utilizada para registrar a data de cadastro das entidades.
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                // Define a DataCadastro como a data atual para entidades adicionadas
                // Se o estado da entidade for Added (ou seja, a entidade foi adicionada),
                // define o valor atual da propriedade "DataCadastro" como a data e hora atuais
                // (DateTime.Now), indicando a data de criação da entidade no contexto.
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                // Define que a DataCadastro não deve ser modificada para entidades modificadas
                // Se o estado da entidade for Modified (ou seja, a entidade foi modificada),
                // define que a propriedade "DataCadastro" não deve ser considerada modificada,
                // o que significa que ela não será atualizada no banco de dados. Isso é útil para
                // evitar que a data de cadastro seja alterada quando uma entidade modificada é salva.
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            // Salva as alterações no banco de dados e retorna verdadeiro se houver mais de 0 alterações
            return await base.SaveChangesAsync() > 0;
        }
    }
}

// Na hora de fazer um commit, na hora de salvar no banco, pega o "ChangeTracker", que o mapeador de mudanças do EF, vou buscar por propriedades
// que possua o nome "DataCadastro"