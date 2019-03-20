using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisul.PrestaSys.Repositorio.Migrations
{
    public partial class PrestacaoDB_AddedJustificativaParaAprovacao : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "JustificativaAprovacao",
                "Prestacao");

            migrationBuilder.DropColumn(
                "JustificativaAprovacaoFinanceira",
                "Prestacao");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "JustificativaAprovacao",
                "Prestacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "JustificativaAprovacaoFinanceira",
                "Prestacao",
                nullable: true);
        }
    }
}
