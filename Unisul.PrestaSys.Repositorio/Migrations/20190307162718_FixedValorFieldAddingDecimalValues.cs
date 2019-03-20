using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisul.PrestaSys.Repositorio.Migrations
{
    public partial class FixedValorFieldAddingDecimalValues : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Usuario_Id_GerenteFinanceiroId",
                "Usuario");

            migrationBuilder.DropForeignKey(
                "FK_Usuario_Id_GerenteId",
                "Usuario");

            migrationBuilder.AlterColumn<int>(
                "GerenteId",
                "Usuario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                "GerenteFinanceiroId",
                "Usuario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                "Valor",
                "Prestacao",
                "decimal(18, 0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AddForeignKey(
                "FK_Usuario_Id_GerenteFinanceiroId",
                "Usuario",
                "GerenteFinanceiroId",
                "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                "FK_Usuario_Id_GerenteId",
                "Usuario",
                "GerenteId",
                "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Usuario_Id_GerenteFinanceiroId",
                "Usuario");

            migrationBuilder.DropForeignKey(
                "FK_Usuario_Id_GerenteId",
                "Usuario");

            migrationBuilder.AlterColumn<int>(
                "GerenteId",
                "Usuario",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                "GerenteFinanceiroId",
                "Usuario",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                "Valor",
                "Prestacao",
                "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 0)");

            migrationBuilder.AddForeignKey(
                "FK_Usuario_Id_GerenteFinanceiroId",
                "Usuario",
                "GerenteFinanceiroId",
                "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                "FK_Usuario_Id_GerenteId",
                "Usuario",
                "GerenteId",
                "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
