using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpleadosEBS.Migrations
{
    public partial class shoppingCart1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "platoID",
                table: "ShoppingCartItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_platoID",
                table: "ShoppingCartItems",
                column: "platoID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Plato_platoID",
                table: "ShoppingCartItems",
                column: "platoID",
                principalTable: "Plato",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Plato_platoID",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_platoID",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "platoID",
                table: "ShoppingCartItems");
        }
    }
}
