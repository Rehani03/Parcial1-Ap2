using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcial1_Ap2.Migrations
{
    public partial class CreateProductoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    productoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descripcion = table.Column<string>(maxLength: 40, nullable: false),
                    existencia = table.Column<int>(nullable: false),
                    costo = table.Column<decimal>(nullable: false),
                    valorInventario = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.productoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
