using HorseMarket.Core.Aggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorseMarket.Infra.Data.Mappings
{
    public class HarasMap : IEntityTypeConfiguration<Haras>
    {
        public void Configure(EntityTypeBuilder<Haras> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Dono)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Telefone)
                .HasMaxLength(30)
                .IsRequired(false);

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.QtdCavalos)
                .IsRequired();
        }
    }
}
