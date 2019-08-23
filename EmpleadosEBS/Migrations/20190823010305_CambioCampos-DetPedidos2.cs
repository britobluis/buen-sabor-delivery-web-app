using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpleadosEBS.Migrations
{
    public partial class CambioCamposDetPedidos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetPedido_Articulo_ArticuloID",
                table: "DetPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_DetPedido_Plato_PlatoID",
                table: "DetPedido");

            migrationBuilder.AlterColumn<int>(
                name: "PlatoID",
                table: "DetPedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ArticuloID",
                table: "DetPedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DetPedido_Articulo_ArticuloID",
                table: "DetPedido",
                column: "ArticuloID",
                principalTable: "Articulo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetPedido_Plato_PlatoID",
                table: "DetPedido",
                column: "PlatoID",
                principalTable: "Plato",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetPedido_Articulo_ArticuloID",
                table: "DetPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_DetPedido_Plato_PlatoID",
                table: "DetPedido");

            migrationBuilder.AlterColumn<int>(
                name: "PlatoID",
                table: "DetPedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArticuloID",
                table: "DetPedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetPedido_Articulo_ArticuloID",
                table: "DetPedido",
                column: "ArticuloID",
                principalTable: "Articulo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetPedido_Plato_PlatoID",
                table: "DetPedido",
                column: "PlatoID",
                principalTable: "Plato",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
