using HorseMarket.Core.Aggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorseMarket.Infra.Data.Mappings
{
    public class LanceMap : IEntityTypeConfiguration<Lance>
    {
        public void Configure(EntityTypeBuilder<Lance> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.Valor)
                .IsRequired();

            builder.Property(x => x.DataLance)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Lances)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Lote)
                .WithMany(x => x.Lances)
                .HasForeignKey(x => x.LoteId);
        }
    }
}
