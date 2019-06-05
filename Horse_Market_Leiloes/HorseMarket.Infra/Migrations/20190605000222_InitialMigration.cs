using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseMarket.Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PasswordHash = table.Column<byte[]>(maxLength: 64, nullable: false),
                    PasswordSalt = table.Column<byte[]>(maxLength: 128, nullable: false),
                    Gender = table.Column<string>(maxLength: 100, nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastActive = table.Column<DateTime>(nullable: false),
                    Banido = table.Column<bool>(nullable: false),
                    Arrependido = table.Column<bool>(nullable: false),
                    LocalidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    Cidade = table.Column<string>(maxLength: 100, nullable: false),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    Cep = table.Column<string>(maxLength: 20, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 100, nullable: true),
                    Complemento = table.Column<string>(maxLength: 100, nullable: true),
                    Bairo = table.Column<string>(maxLength: 100, nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidade_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Haras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Dono = table.Column<string>(maxLength: 100, nullable: true),
                    Telefone = table.Column<string>(maxLength: 30, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    QtdCavalos = table.Column<int>(nullable: false),
                    LocalidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Haras_Localidade_LocalidadeId",
                        column: x => x.LocalidadeId,
                        principalTable: "Localidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cavalo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Raca = table.Column<string>(maxLength: 100, nullable: false),
                    Genero = table.Column<string>(maxLength: 20, nullable: false),
                    Pelagem = table.Column<string>(maxLength: 100, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Estagio = table.Column<string>(maxLength: 100, nullable: false),
                    HarasId = table.Column<int>(nullable: false),
                    LocalidadeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Mae = table.Column<string>(maxLength: 100, nullable: false),
                    Pai = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cavalo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cavalo_Haras_HarasId",
                        column: x => x.HarasId,
                        principalTable: "Haras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cavalo_Localidade_LocalidadeId",
                        column: x => x.LocalidadeId,
                        principalTable: "Localidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cavalo_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Foto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    PublicId = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CavaloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foto_Cavalo_CavaloId",
                        column: x => x.CavaloId,
                        principalTable: "Cavalo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Foto_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leiloes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Fim = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    FotoId = table.Column<int>(nullable: false),
                    Contato = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leiloes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leiloes_Foto_FotoId",
                        column: x => x.FotoId,
                        principalTable: "Foto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    CavaloId = table.Column<int>(nullable: false),
                    LanceMinimo = table.Column<decimal>(nullable: false),
                    Cobertura = table.Column<int>(nullable: false),
                    LanceAtualId = table.Column<int>(nullable: false),
                    Incremento = table.Column<decimal>(nullable: false),
                    LeilaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lote_Cavalo_CavaloId",
                        column: x => x.CavaloId,
                        principalTable: "Cavalo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lote_Leiloes_LeilaoId",
                        column: x => x.LeilaoId,
                        principalTable: "Leiloes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    LoteId = table.Column<int>(nullable: false),
                    DataLance = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lance_Lote_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lance_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cavalo_HarasId",
                table: "Cavalo",
                column: "HarasId");

            migrationBuilder.CreateIndex(
                name: "IX_Cavalo_LocalidadeId",
                table: "Cavalo",
                column: "LocalidadeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cavalo_UserId",
                table: "Cavalo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_CavaloId",
                table: "Foto",
                column: "CavaloId");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_UserId",
                table: "Foto",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Haras_LocalidadeId",
                table: "Haras",
                column: "LocalidadeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lance_LoteId",
                table: "Lance",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lance_UserId",
                table: "Lance",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leiloes_FotoId",
                table: "Leiloes",
                column: "FotoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Localidade_UserId",
                table: "Localidade",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lote_CavaloId",
                table: "Lote",
                column: "CavaloId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lote_LeilaoId",
                table: "Lote",
                column: "LeilaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lance");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropTable(
                name: "Leiloes");

            migrationBuilder.DropTable(
                name: "Foto");

            migrationBuilder.DropTable(
                name: "Cavalo");

            migrationBuilder.DropTable(
                name: "Haras");

            migrationBuilder.DropTable(
                name: "Localidade");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
