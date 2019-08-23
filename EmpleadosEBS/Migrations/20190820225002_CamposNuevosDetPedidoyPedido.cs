using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpleadosEBS.Migrations
{
    public partial class CamposNuevosDetPedidoyPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Plato_platoID",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "platoID",
                table: "ShoppingCartItems",
                newName: "PlatoID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_platoID",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_PlatoID");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "DetPedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "DetPedido",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Plato_PlatoID",
                table: "ShoppingCartItems",
                column: "PlatoID",
                principalTable: "Plato",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Plato_PlatoID",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "DetPedido");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "DetPedido");

            migrationBuilder.RenameColumn(
                name: "PlatoID",
                table: "ShoppingCartItems",
                newName: "platoID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_PlatoID",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_platoID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Plato_platoID",
                table: "ShoppingCartItems",
                column: "platoID",
                principalTable: "Plato",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
