using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpleadosEBS.Migrations
{
    public partial class agregueusuarioapedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCartId",
                table: "ShoppingCartItems",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Pedido",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_UserId",
                table: "Pedido",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_AspNetUsers_UserId",
                table: "Pedido",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_AspNetUsers_UserId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_UserId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pedido");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCartId",
                table: "ShoppingCartItems",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
