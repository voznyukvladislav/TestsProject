using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTestsDb.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Answears");

            migrationBuilder.CreateTable(
                name: "AnswearValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswearValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswearValue_Answears_AnswearId",
                        column: x => x.AnswearId,
                        principalTable: "Answears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswearValue_AnswearId",
                table: "AnswearValue",
                column: "AnswearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswearValue");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Answears",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
