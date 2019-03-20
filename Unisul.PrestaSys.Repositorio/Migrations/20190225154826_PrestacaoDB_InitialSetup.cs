using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisul.PrestaSys.Repositorio.Migrations
{
    public partial class PrestacaoDB_InitialSetup : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Prestacao");

            migrationBuilder.DropTable(
                "Usuario");

            migrationBuilder.DropTable(
                "PrestacaoStatus");

            migrationBuilder.DropTable(
                "PrestacaoTipo");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "PrestacaoStatus",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_PrestacaoStatus", x => x.Id); });

            migrationBuilder.CreateTable(
                "PrestacaoTipo",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_PrestacaoTipo", x => x.Id); });

            migrationBuilder.CreateTable(
                "Usuario",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    FlagGerente = table.Column<bool>(nullable: false),
                    FlagGerenteFinanceiro = table.Column<bool>(nullable: false),
                    GerenteFinanceiroId = table.Column<int>(nullable: true),
                    GerenteId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Senha = table.Column<string>(maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        "FK_Usuario_Id_GerenteFinanceiroId",
                        x => x.GerenteFinanceiroId,
                        "Usuario",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Usuario_Id_GerenteId",
                        x => x.GerenteId,
                        "Usuario",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Prestacao",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    AprovadorFinanceiroId = table.Column<int>(nullable: false),
                    AprovadorId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>("datetime", nullable: false),
                    EmitenteId = table.Column<int>(nullable: false),
                    ImagemComprovante = table.Column<byte[]>(nullable: true),
                    Justificativa = table.Column<string>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    TipoId = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>("decimal(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestacao", x => x.Id);
                    table.ForeignKey(
                        "FK_Usuario_PrestacaoAprovadorFinanceiroId",
                        x => x.AprovadorFinanceiroId,
                        "Usuario",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Usuario_PrestacaoAprovadorId",
                        x => x.AprovadorId,
                        "Usuario",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Usuario_PrestacaoEmitenteId",
                        x => x.EmitenteId,
                        "Usuario",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_PrestacaoStatus_Prestacao",
                        x => x.StatusId,
                        "PrestacaoStatus",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_PrestacaoTipo_Prestacao",
                        x => x.TipoId,
                        "PrestacaoTipo",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                "PrestacaoStatus",
                new[] {"Id", "Status"},
                new object[,]
                {
                    {1, "Iniciada"},
                    {2, "Em Aprovação Operacional"},
                    {3, "Em Aprovação Financeira"},
                    {4, "Finalizada"},
                    {5, "Rejeitada"}
                });

            migrationBuilder.InsertData(
                "PrestacaoTipo",
                new[] {"Id", "Tipo"},
                new object[,]
                {
                    {1, "Viagem"},
                    {2, "Curso de Idioma"},
                    {3, "Alimentação"},
                    {4, "Taxi/Uber"}
                });

            migrationBuilder.InsertData(
                "Usuario",
                new[]
                {
                    "Id", "Email", "FlagGerente", "FlagGerenteFinanceiro", "GerenteFinanceiroId", "GerenteId", "Nome",
                    "Senha", "Sobrenome"
                },
                new object[] {1, "cristian.fernandes@unisul.br", true, true, 1, 1, "Cristian", "asdf", "Fernandes"});

            migrationBuilder.CreateIndex(
                "IX_Prestacao_AprovadorFinanceiroId",
                "Prestacao",
                "AprovadorFinanceiroId");

            migrationBuilder.CreateIndex(
                "IX_Prestacao_AprovadorId",
                "Prestacao",
                "AprovadorId");

            migrationBuilder.CreateIndex(
                "IX_Prestacao_EmitenteId",
                "Prestacao",
                "EmitenteId");

            migrationBuilder.CreateIndex(
                "IX_Prestacao_StatusId",
                "Prestacao",
                "StatusId");

            migrationBuilder.CreateIndex(
                "IX_Prestacao_TipoId",
                "Prestacao",
                "TipoId");

            migrationBuilder.CreateIndex(
                "U_UsuarioEmail",
                "Usuario",
                "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Usuario_GerenteFinanceiroId",
                "Usuario",
                "GerenteFinanceiroId");

            migrationBuilder.CreateIndex(
                "IX_Usuario_GerenteId",
                "Usuario",
                "GerenteId");
        }
    }
}
