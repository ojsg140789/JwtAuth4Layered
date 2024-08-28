using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtAuth4Layered.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameContraseniaPorPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contraseña",
                table: "Clientes",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Clientes",
                newName: "Contraseña");
        }
    }
}
