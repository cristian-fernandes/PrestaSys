using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisul.PrestaSys.Repositorio.Migrations
{
    public partial class PrestacaoDB_FixForPrestacaoStatus : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                "PrestacaoStatus",
                "Id",
                1,
                "Status",
                "Iniciada");

            migrationBuilder.UpdateData(
                "PrestacaoStatus",
                "Id",
                2,
                "Status",
                "Em Aprovação Operacional");

            migrationBuilder.UpdateData(
                "PrestacaoStatus",
                "Id",
                3,
                "Status",
                "Em Aprovação Financeira");

            migrationBuilder.UpdateData(
                "PrestacaoStatus",
                "Id",
                4,
                "Status",
                "Finalizada");

            migrationBuilder.InsertData(
                "PrestacaoStatus",
                new[] {"Id", "Status"},
                new object[] {5, "Rejeitada"});
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "PrestacaoStatus",
                "Id",
                5);

            migrationBuilder.UpdateData(
                "PrestacaoStatus",
                "Id",
                1,
                "Status",
                "Em Aprovação Operacional");

            migrationBuilder.UpdateData(
                "PrestacaoStatus",
                "Id",
                2,
                "Status",
                "Em Aprovação Financeira");

            migrationBuilder.UpdateData(
                "PrestacaoStatus",
                "Id",
                3,
                "Status",
                "Finalizada");

            migrationBuilder.UpdateData(
                "PrestacaoStatus",
                "Id",
                4,
                "Status",
                "Rejeitada");
        }
    }
}
