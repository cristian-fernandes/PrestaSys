using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisul.PrestaSys.Repositorio.Migrations
{
    public partial class CascadeNoEmitenteDaPrestacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_PrestacaoEmitenteId",
                table: "Prestacao");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_PrestacaoEmitenteId",
                table: "Prestacao",
                column: "EmitenteId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_PrestacaoEmitenteId",
                table: "Prestacao");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_PrestacaoEmitenteId",
                table: "Prestacao",
                column: "EmitenteId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
