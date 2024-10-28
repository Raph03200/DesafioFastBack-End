using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioFast.Migrations
{
    /// <inheritdoc />
    public partial class Revolutionmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbColaborador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbColaborador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbPresenca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    ColaboradorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPresenca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbWorkshop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRealizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbWorkshop", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbColaborador");

            migrationBuilder.DropTable(
                name: "DbPresenca");

            migrationBuilder.DropTable(
                name: "DbWorkshop");
        }
    }
}
