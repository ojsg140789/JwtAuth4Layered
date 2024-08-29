using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtAuth4Layered.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionAjusteTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Tiendas_TiendaId",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_TiendaId",
                table: "Articulos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Articulos_TiendaId",
                table: "Articulos",
                column: "TiendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Tiendas_TiendaId",
                table: "Articulos",
                column: "TiendaId",
                principalTable: "Tiendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
