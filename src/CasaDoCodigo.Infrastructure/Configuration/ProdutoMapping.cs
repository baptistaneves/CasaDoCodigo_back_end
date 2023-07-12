namespace CasaDoCodigo.Infrastructure.Configuration;

internal class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Titulo)
            .HasColumnType("varchar(255))");

        builder.Property(c => c.Imagem)
            .HasColumnType("varchar(255))");

        builder.Property(c => c.Descricao)
            .HasColumnType("varchar(max)");

        builder.ToTable("Produtos");
    }
}
