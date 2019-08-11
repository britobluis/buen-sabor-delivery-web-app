using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpleadosEBS.Migrations
{
    public partial class PlatoAgregadoDescripcionImagenCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Plato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Plato",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Plato");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Plato");
        }
    }
}
