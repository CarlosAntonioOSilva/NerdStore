/*
    Este código define a classe ProdutoMapping, que é responsável pela configuração do 
    mapeamento da entidade Produto para o banco de dados utilizando o Entity Framework Core.
 */

// Importa o namespace Microsoft.EntityFrameworkCore, que contém classes para acesso a dados com o Entity Framework Core.
using Microsoft.EntityFrameworkCore;
// Importa o namespace Microsoft.EntityFrameworkCore.Metadata.Builders, que contém interfaces para configuração de entidades do Entity Framework Core.
using Microsoft.EntityFrameworkCore.Metadata.Builders;
// Importa o namespace NerdStore.Catalogo.Domain, que contém as definições de domínio relacionadas aos produtos.
using NerdStore.Catalogo.Domain; 

namespace NerdStore.Catalogo.Data.Mappings
{
    // Classe responsável pela configuração de mapeamento da entidade Produto
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        // Método de "IEntityTypeConfiguration", que configura o mapeamento da entidade Produto
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            // Configura a chave primária da entidade Produto como o campo Id
            builder.HasKey(c => c.Id);

            // Configura a propriedade Nome da entidade Produto como obrigatória e do tipo varchar(250)
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");


            // Configura a propriedade Descricao da entidade Produto como obrigatória e do tipo varchar(500)
            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            // Configura a propriedade Imagem da entidade Produto como obrigatória e do tipo varchar(250)
            builder.Property(c => c.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");

            // Configura a propriedade Dimensoes da entidade Produto como uma propriedade complexa
            builder.OwnsOne(c => c.Dimensoes, cm =>
            {
                // Configura a propriedade Altura da propriedade complexa Dimensoes como coluna Altura do tipo int
                cm.Property(c => c.Altura)
                    .HasColumnName("Altura")
                    .HasColumnType("int");

                // Configura a propriedade Largura da propriedade complexa Dimensoes como coluna Largura do tipo int
                cm.Property(c => c.Largura)
                    .HasColumnName("Largura")
                    .HasColumnType("int");

                // Configura a propriedade Profundidade da propriedade complexa Dimensoes como coluna Profundidade do tipo int
                cm.Property(c => c.Profundidade)
                    .HasColumnName("Profundidade")
                    .HasColumnType("int");
            });

            // Configura o nome da tabela no banco de dados como "Produtos"
            builder.ToTable("Produtos");
        }
    }
}
