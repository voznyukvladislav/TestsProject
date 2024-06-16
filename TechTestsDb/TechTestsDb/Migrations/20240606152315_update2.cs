using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTestsDb.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswearValue_Answears_AnswearId",
                table: "AnswearValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswearValue",
                table: "AnswearValue");

            migrationBuilder.RenameTable(
                name: "AnswearValue",
                newName: "AnswearValues");

            migrationBuilder.RenameIndex(
                name: "IX_AnswearValue_AnswearId",
                table: "AnswearValues",
                newName: "IX_AnswearValues_AnswearId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswearValues",
                table: "AnswearValues",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswearValues_Answears_AnswearId",
                table: "AnswearValues",
                column: "AnswearId",
                principalTable: "Answears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswearValues_Answears_AnswearId",
                table: "AnswearValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswearValues",
                table: "AnswearValues");

            migrationBuilder.RenameTable(
                name: "AnswearValues",
                newName: "AnswearValue");

            migrationBuilder.RenameIndex(
                name: "IX_AnswearValues_AnswearId",
                table: "AnswearValue",
                newName: "IX_AnswearValue_AnswearId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswearValue",
                table: "AnswearValue",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswearValue_Answears_AnswearId",
                table: "AnswearValue",
                column: "AnswearId",
                principalTable: "Answears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
