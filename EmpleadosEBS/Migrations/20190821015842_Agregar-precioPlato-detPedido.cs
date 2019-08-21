using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpleadosEBS.Migrations
{
    public partial class AgregarprecioPlatodetPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "DetPedido",
                newName: "PrecioPlato");

            migrationBuilder.AddColumn<double>(
                name: "PrecioArticulo",
                table: "DetPedido",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioArticulo",
                table: "DetPedido");

            migrationBuilder.RenameColumn(
                name: "PrecioPlato",
                table: "DetPedido",
                newName: "Precio");
        }
    }
}
