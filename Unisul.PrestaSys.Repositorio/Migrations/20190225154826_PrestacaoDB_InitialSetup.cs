using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisul.PrestaSys.Repositorio.Migrations
{
    public partial class PrestacaoDB_InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrestacaoStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestacaoStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrestacaoTipo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestacaoTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        name: "FK_Usuario_Id_GerenteFinanceiroId",
                        column: x => x.GerenteFinanceiroId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Id_GerenteId",
                        column: x => x.GerenteId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prestacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AprovadorFinanceiroId = table.Column<int>(nullable: false),
                    AprovadorId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmitenteId = table.Column<int>(nullable: false),
                    ImagemComprovante = table.Column<byte[]>(nullable: true),
                    Justificativa = table.Column<string>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    TipoId = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_PrestacaoAprovadorFinanceiroId",
                        column: x => x.AprovadorFinanceiroId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_PrestacaoAprovadorId",
                        column: x => x.AprovadorId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_PrestacaoEmitenteId",
                        column: x => x.EmitenteId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrestacaoStatus_Prestacao",
                        column: x => x.StatusId,
                        principalTable: "PrestacaoStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrestacaoTipo_Prestacao",
                        column: x => x.TipoId,
                        principalTable: "PrestacaoTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PrestacaoStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Iniciada" },
                    { 2, "Em Aprovação Operacional" },
                    { 3, "Em Aprovação Financeira" },
                    { 4, "Finalizada" },
                    { 5, "Rejeitada" }
                });

            migrationBuilder.InsertData(
                table: "PrestacaoTipo",
                columns: new[] { "Id", "Tipo" },
                values: new object[,]
                {
                    { 1, "Viagem" },
                    { 2, "Curso de Idioma" },
                    { 3, "Alimentação" },
                    { 4, "Taxi/Uber" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "FlagGerente", "FlagGerenteFinanceiro", "GerenteFinanceiroId", "GerenteId", "Nome", "Senha", "Sobrenome" },
                values: new object[] { 1, "cristian.fernandes@unisul.br", true, true, 1, 1, "Cristian", "asdf", "Fernandes" });

            migrationBuilder.CreateIndex(
                name: "IX_Prestacao_AprovadorFinanceiroId",
                table: "Prestacao",
                column: "AprovadorFinanceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestacao_AprovadorId",
                table: "Prestacao",
                column: "AprovadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestacao_EmitenteId",
                table: "Prestacao",
                column: "EmitenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestacao_StatusId",
                table: "Prestacao",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestacao_TipoId",
                table: "Prestacao",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "U_UsuarioEmail",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_GerenteFinanceiroId",
                table: "Usuario",
                column: "GerenteFinanceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_GerenteId",
                table: "Usuario",
                column: "GerenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestacao");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "PrestacaoStatus");

            migrationBuilder.DropTable(
                name: "PrestacaoTipo");
        }
    }
}
