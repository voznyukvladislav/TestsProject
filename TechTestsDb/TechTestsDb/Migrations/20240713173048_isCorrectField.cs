﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTestsDb.Migrations
{
    /// <inheritdoc />
    public partial class isCorrectField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "AnswerValues",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "AnswerValues");
        }
    }
}
