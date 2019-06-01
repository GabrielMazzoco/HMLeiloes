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
                .IsRequired();

            builder.Property(x => x.Dono)
                .IsRequired(false);

            builder.Property(x => x.Telefone)
                .IsRequired(false);

            builder.Property(x => x.Email)
                .IsRequired(false);

            builder.Property(x => x.QtdCavalos)
                .IsRequired();
        }
    }
}
