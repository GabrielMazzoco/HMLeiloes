using HorseMarket.Core.Aggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorseMarket.Infra.Data.Mappings
{
    public class CavaloMap : IEntityTypeConfiguration<Cavalo>
    {
        public void Configure(EntityTypeBuilder<Cavalo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Raca)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Genero)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Pelagem)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.DataNascimento)
                .IsRequired();

            builder.Property(x => x.Estagio)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Pai)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Mae)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.Haras)
                .WithMany(x => x.Cavalos)
                .HasForeignKey(x => x.HarasId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
