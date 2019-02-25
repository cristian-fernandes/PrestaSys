using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class PrestacaoDB_AddedJustificativaParaAprovacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JustificativaAprovacao",
                table: "Prestacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JustificativaAprovacaoFinanceira",
                table: "Prestacao",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JustificativaAprovacao",
                table: "Prestacao");

            migrationBuilder.DropColumn(
                name: "JustificativaAprovacaoFinanceira",
                table: "Prestacao");
        }
    }
}
