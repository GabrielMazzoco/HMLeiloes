using HorseMarket.Core.Aggregate;
using HorseMarket.Core.SharedKernel.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorseMarket.Infra.Data.Mappings
{
    public class FotoMap : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.Url)
                .IsRequired();

            builder.Property(x => x.DateAdded)
                .IsRequired();

            builder.Property(x => x.IsMain)
                .IsRequired();

            builder.Property(x => x.PublicId)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithOne(x => x.Foto)
                .HasForeignKey<Foto>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Leilao)
                .WithOne(x => x.Foto)
                .HasForeignKey<Leilao>(x => x.FotoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Cavalo)
                .WithMany(x => x.Fotos)
                .HasForeignKey(x => x.CavaloId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
