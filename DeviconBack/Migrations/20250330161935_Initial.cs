using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeviconBack.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ValuteCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuteCourses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Valutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nominal = table.Column<int>(type: "int", nullable: false),
                    CharCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VunitRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValuteCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Valutes_ValuteCourses_ValuteCourseId",
                        column: x => x.ValuteCourseId,
                        principalTable: "ValuteCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Valutes_ValuteCourseId",
                table: "Valutes",
                column: "ValuteCourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Valutes");

            migrationBuilder.DropTable(
                name: "ValuteCourses");
        }
    }
}
