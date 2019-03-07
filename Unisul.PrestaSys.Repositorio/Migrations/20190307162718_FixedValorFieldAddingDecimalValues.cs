using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisul.PrestaSys.Repositorio.Migrations
{
    public partial class FixedValorFieldAddingDecimalValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Id_GerenteFinanceiroId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Id_GerenteId",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "GerenteId",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GerenteFinanceiroId",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Prestacao",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 0)");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Id_GerenteFinanceiroId",
                table: "Usuario",
                column: "GerenteFinanceiroId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Id_GerenteId",
                table: "Usuario",
                column: "GerenteId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Id_GerenteFinanceiroId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Id_GerenteId",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "GerenteId",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GerenteFinanceiroId",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Prestacao",
                type: "decimal(18, 0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Id_GerenteFinanceiroId",
                table: "Usuario",
                column: "GerenteFinanceiroId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Id_GerenteId",
                table: "Usuario",
                column: "GerenteId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
