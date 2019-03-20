using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisul.PrestaSys.Repositorio.Migrations
{
    public partial class CascadeNoEmitenteDaPrestacao : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Usuario_PrestacaoEmitenteId",
                "Prestacao");

            migrationBuilder.AddForeignKey(
                "FK_Usuario_PrestacaoEmitenteId",
                "Prestacao",
                "EmitenteId",
                "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Usuario_PrestacaoEmitenteId",
                "Prestacao");

            migrationBuilder.AddForeignKey(
                "FK_Usuario_PrestacaoEmitenteId",
                "Prestacao",
                "EmitenteId",
                "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
