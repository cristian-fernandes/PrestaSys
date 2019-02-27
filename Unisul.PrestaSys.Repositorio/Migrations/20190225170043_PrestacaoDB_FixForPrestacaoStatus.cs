using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisul.PrestaSys.Repositorio.Migrations
{
    public partial class PrestacaoDB_FixForPrestacaoStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PrestacaoStatus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "PrestacaoStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Em Aprovação Operacional");

            migrationBuilder.UpdateData(
                table: "PrestacaoStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Em Aprovação Financeira");

            migrationBuilder.UpdateData(
                table: "PrestacaoStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Finalizada");

            migrationBuilder.UpdateData(
                table: "PrestacaoStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: "Rejeitada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PrestacaoStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Iniciada");

            migrationBuilder.UpdateData(
                table: "PrestacaoStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Em Aprovação Operacional");

            migrationBuilder.UpdateData(
                table: "PrestacaoStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Em Aprovação Financeira");

            migrationBuilder.UpdateData(
                table: "PrestacaoStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: "Finalizada");

            migrationBuilder.InsertData(
                table: "PrestacaoStatus",
                columns: new[] { "Id", "Status" },
                values: new object[] { 5, "Rejeitada" });
        }
    }
}
