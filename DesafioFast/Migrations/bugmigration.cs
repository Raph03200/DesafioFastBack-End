using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioFast.Migrations
{
    /// <inheritdoc />
    public partial class bugmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ColaboradorId",
                table: "DbPresenca",
                newName: "ColaboradorIds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ColaboradorIds",
                table: "DbPresenca",
                newName: "ColaboradorId");
        }
    }
}
