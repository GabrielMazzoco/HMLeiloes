﻿using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.SharedKernel.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorseMarket.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.Username)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.PasswordSalt)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(x => x.Gender)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.IsAdmin)
                .IsRequired();

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.Created)
                .IsRequired();

            builder.Property(x => x.LastActive)
                .IsRequired();

            builder.Property(x => x.Banido)
                .IsRequired();

            builder.Property(x => x.Arrependido)
                .IsRequired();

            builder.HasMany(x => x.Cavalos)
                .WithOne(x => x.Dono)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Localidade)
                .WithOne(x => x.User)
                .HasForeignKey<User>(x => x.LocalidadeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
        }
    }
}
