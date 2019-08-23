using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpleadosEBS.Migrations
{
    public partial class AgregueCamposFaltantesDetPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetPedido_Pedido_PedidoID",
                table: "DetPedido");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.AlterColumn<double>(
                name: "Cantidad",
                table: "Receta",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "PrecioVenta",
                table: "Plato",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "Aprobado",
                table: "Plato",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumeroPedido",
                table: "Pedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Denominacion",
                table: "EstadoPedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PedidoID",
                table: "DetPedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "Aprobado",
                table: "Articulo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_DetPedido_Pedido_PedidoID",
                table: "DetPedido",
                column: "PedidoID",
                principalTable: "Pedido",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetPedido_Pedido_PedidoID",
                table: "DetPedido");

            migrationBuilder.DropColumn(
                name: "Aprobado",
                table: "Plato");

            migrationBuilder.DropColumn(
                name: "NumeroPedido",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Denominacion",
                table: "EstadoPedido");

            migrationBuilder.DropColumn(
                name: "Aprobado",
                table: "Articulo");

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "Receta",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "PrecioVenta",
                table: "Plato",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "PedidoID",
                table: "DetPedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstadoPedido = table.Column<int>(nullable: false),
                    PedidoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comanda_Pedido_PedidoID",
                        column: x => x.PedidoID,
                        principalTable: "Pedido",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_PedidoID",
                table: "Comanda",
                column: "PedidoID");

            migrationBuilder.AddForeignKey(
                name: "FK_DetPedido_Pedido_PedidoID",
                table: "DetPedido",
                column: "PedidoID",
                principalTable: "Pedido",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
