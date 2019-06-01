﻿// <auto-generated />
using System;
using HorseMarket.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HorseMarket.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HorseMarket.Core.Aggregate.Entities.Cavalo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Estagio")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("HarasId");

                    b.Property<int>("LocalidadeId");

                    b.Property<string>("Mae")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Pai")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Pelagem")
                        .HasMaxLength(100);

                    b.Property<string>("Raca")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("HarasId");

                    b.HasIndex("LocalidadeId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Cavalo");
                });

            modelBuilder.Entity("HorseMarket.Core.Aggregate.Entities.Haras", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<string>("Dono")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<int>("LocalidadeId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("QtdCavalos");

                    b.Property<string>("Telefone")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("LocalidadeId")
                        .IsUnique();

                    b.ToTable("Haras");
                });

            modelBuilder.Entity("HorseMarket.Core.Aggregate.Entities.Lance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataLance");

                    b.Property<int>("LoteId");

                    b.Property<int>("UserId");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("LoteId");

                    b.HasIndex("UserId");

                    b.ToTable("Lance");
                });

            modelBuilder.Entity("HorseMarket.Core.Aggregate.Entities.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<int>("CavaloId");

                    b.Property<int>("Cobertura");

                    b.Property<decimal>("Incremento");

                    b.Property<int>("LanceAtualId");

                    b.Property<decimal>("LanceMinimo");

                    b.Property<int>("LeilaoId");

                    b.HasKey("Id");

                    b.HasIndex("CavaloId")
                        .IsUnique();

                    b.HasIndex("LeilaoId");

                    b.ToTable("Lote");
                });

            modelBuilder.Entity("HorseMarket.Core.Aggregate.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Arrependido");

                    b.Property<bool>("Ativo");

                    b.Property<bool>("Banido");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("IsAdmin");

                    b.Property<DateTime>("LasActive");

                    b.Property<int>("LocalidadeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("LocalidadeId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("HorseMarket.Core.Aggregate.Leilao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<DateTime>("Fim");

                    b.Property<int>("FotoId");

                    b.Property<DateTime>("Inicio");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("FotoId")
                        .IsUnique();

                    b.ToTable("Leiloes");
                });

            modelBuilder.Entity("HorseMarket.Core.SharedKernel.Entitites.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<int>("CavaloId");

                    b.Property<DateTime>("DateAdded");

                    b.Property<bool>("IsMain");

                    b.Property<string>("PublicId")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CavaloId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Foto");
                });

            modelBuilder.Entity("HorseMarket.Core.SharedKernel.Entitites.Localidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<string>("Bairo")
                        .HasMaxLength(100);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Complemento")
                        .HasMaxLength(100);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Logradouro")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Localidade");
                });

            modelBuilder.Entity("HorseMarket.Core.Aggregate.Entities.Cavalo", b =>
                {
                    b.HasOne("HorseMarket.Core.Aggregate.Entities.Haras", "Haras")
                        .WithMany("Cavalos")
                        .HasForeignKey("HarasId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HorseMarket.Core.SharedKernel.Entitites.Localidade", "Localidade")
                        .WithOne("Cavalo")
                        .HasForeignKey("HorseMarket.Core.Aggregate.Entities.Cavalo", "LocalidadeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HorseMarket.Core.Aggregate.Entities.User", "Dono")
                        .WithMany("Cavalos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HorseMarket.Core.Aggregate.Entities.Haras", b =>
                {
                    b.HasOne("HorseMarket.Core.SharedKernel.Entitites.Localidade", "Localidade")
                        .WithOne("Haras")
                        .HasForeignKey("HorseMarket.Core.Aggregate.Entities.Haras", "LocalidadeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HorseMarket.Core.Aggregate.Entities.Lance", b =>
                {
                    b.HasOne("HorseMarket.Core.Aggregate.Entities.Lote", "Lote")
                        .WithMany("Lances")
                        .HasForeignKey("LoteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HorseMarket.Core.Aggregate.Entities.User", "User")
                        .WithMany("Lances")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HorseMarket.Core.Aggregate.Entities.Lote", b =>
                {
                    b.HasOne("HorseMarket.Core.Aggregate.Entities.Cavalo", "Cavalo")
                        .WithOne("Lote")
                        .HasForeignKey("HorseMarket.Core.Aggregate.Entities.Lote", "CavaloId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HorseMarket.Core.Aggregate.Leilao", "Leilao")
                        .WithMany("Lotes")
                        .HasForeignKey("LeilaoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HorseMarket.Core.Aggregate.Entities.User", b =>
                {
                    b.HasOne("HorseMarket.Core.SharedKernel.Entitites.Localidade", "Localidade")
                        .WithOne("User")
                        .HasForeignKey("HorseMarket.Core.Aggregate.Entities.User", "LocalidadeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HorseMarket.Core.Aggregate.Leilao", b =>
                {
                    b.HasOne("HorseMarket.Core.SharedKernel.Entitites.Foto", "Foto")
                        .WithOne("Leilao")
                        .HasForeignKey("HorseMarket.Core.Aggregate.Leilao", "FotoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HorseMarket.Core.SharedKernel.Entitites.Foto", b =>
                {
                    b.HasOne("HorseMarket.Core.Aggregate.Entities.Cavalo", "Cavalo")
                        .WithMany("Fotos")
                        .HasForeignKey("CavaloId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HorseMarket.Core.Aggregate.Entities.User", "User")
                        .WithOne("Foto")
                        .HasForeignKey("HorseMarket.Core.SharedKernel.Entitites.Foto", "UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
