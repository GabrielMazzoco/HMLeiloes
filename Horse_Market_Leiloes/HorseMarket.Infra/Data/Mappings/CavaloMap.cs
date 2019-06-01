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
                .IsRequired();

            builder.Property(x => x.Raca)
                .IsRequired();

            builder.Property(x => x.Genero)
                .IsRequired();

            builder.Property(x => x.Pelagem)
                .IsRequired(false);

            builder.Property(x => x.DataNascimento)
                .IsRequired();

            builder.Property(x => x.Estagio)
                .IsRequired();

            builder.HasOne(x => x.Mae)
                .WithMany(x => x.Pais)
                .HasForeignKey(x => x.MaeId);

            builder.HasOne(x => x.Pai)
                .WithMany(x => x.Pais)
                .HasForeignKey(x => x.PaiId);

            builder.HasOne(x => x.Haras)
                .WithMany(x => x.Cavalos)
                .HasForeignKey(x => x.HarasId);
        }
    }
}
