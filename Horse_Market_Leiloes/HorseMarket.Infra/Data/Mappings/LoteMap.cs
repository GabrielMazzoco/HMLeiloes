using HorseMarket.Core.Aggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorseMarket.Infra.Data.Mappings
{
    public class LoteMap : IEntityTypeConfiguration<Lote>
    {
        public void Configure(EntityTypeBuilder<Lote> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.LanceMinimo)
                .IsRequired();

            builder.Property(x => x.Cobertura)
                .IsRequired();

            builder.Property(x => x.LanceAtualId)
                .IsRequired();

            builder.Property(x => x.Incremento)
                .IsRequired();

            builder.HasOne(x => x.Leilao)
                .WithMany(x => x.Lotes)
                .HasForeignKey(x => x.LeilaoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Cavalo)
                .WithOne(x => x.Lote)
                .HasForeignKey<Lote>(x => x.CavaloId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
