using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtAuth4Layered.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionEliminarComputoSubtotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                table: "DetallesCompras",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldComputedColumnSql: "[Cantidad] * [Precio]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                table: "DetallesCompras",
                type: "decimal(10,2)",
                nullable: false,
                computedColumnSql: "[Cantidad] * [Precio]",
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");
        }
    }
}
