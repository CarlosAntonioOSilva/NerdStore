// Importa o namespace Microsoft.EntityFrameworkCore, que contém classes para acesso a dados com o Entity Framework Core.
using Microsoft.EntityFrameworkCore;
// Importa o namespace Microsoft.EntityFrameworkCore.Metadata.Builders, que contém interfaces para configuração de entidades do Entity Framework Core.
using Microsoft.EntityFrameworkCore.Metadata.Builders;
// Importa o namespace NerdStore.Catalogo.Domain, que contém as definições de domínio relacionadas às categorias.
using NerdStore.Catalogo.Domain; 

namespace NerdStore.Catalogo.Data.Mappings
{
    // Classe responsável pela configuração de mapeamento da entidade Categoria
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        // Método que configura o mapeamento da entidade Categoria
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            // Configura a chave primária da entidade Categoria como o campo Id
            builder.HasKey(c => c.Id);

            // Configura a propriedade Nome da entidade Categoria como obrigatória e do tipo varchar(250)
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            // Configura o relacionamento 1:N entre Categorias e Produtos
            // HasMany = TemMuitos
            // WithOne = ComUm
            builder.HasMany(c => c.Produtos) // Uma categoria tem muitos produtos
                .WithOne(p => p.Categoria) // Um produto pertence a uma categoria
                .HasForeignKey(p => p.CategoriaId); // Chave estrangeira de Produto referenciando Categoria

            // Configura o nome da tabela no banco de dados como "Categorias"
            builder.ToTable("Categorias");
        }
    }
}
