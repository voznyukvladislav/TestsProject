using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTestsDb.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Descriptions_DescriptionId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "DescriptionId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Descriptions_DescriptionId",
                table: "Questions",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Descriptions_DescriptionId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "DescriptionId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Descriptions_DescriptionId",
                table: "Questions",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
