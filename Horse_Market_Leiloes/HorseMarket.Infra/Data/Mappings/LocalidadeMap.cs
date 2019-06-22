using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.SharedKernel.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorseMarket.Infra.Data.Mappings
{
    public class LocalidadeMap : IEntityTypeConfiguration<Localidade>
    {
        public void Configure(EntityTypeBuilder<Localidade> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.Cidade)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Estado)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Cep)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Logradouro)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Complemento)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Bairo)
                .HasMaxLength(100)
                .IsRequired(false);
        }
    }
}
