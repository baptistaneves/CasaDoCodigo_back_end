namespace CasaDoCodigo.Infrastructure.Configuration;

internal class CategoriaMapping : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Descricao)
            .HasColumnType("varchar(50)");

        builder.HasMany(c => c.Produtos)
            .WithOne(p => p.Categoria)
            .HasForeignKey(p => p.CategoriaId);

        builder.ToTable("Categorias");
    }
}
