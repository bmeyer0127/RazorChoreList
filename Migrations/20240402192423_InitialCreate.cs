﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorChoreList.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chore",
                columns: table => new
                {
                    ChoreId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChoreName = table.Column<string>(type: "TEXT", nullable: false),
                    CompletionStatus = table.Column<string>(type: "TEXT", nullable: false),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chore", x => x.ChoreId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ChoreId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_Chore_ChoreId",
                        column: x => x.ChoreId,
                        principalTable: "Chore",
                        principalColumn: "ChoreId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chore_PersonId",
                table: "Chore",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ChoreId",
                table: "Person",
                column: "ChoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chore_Person_PersonId",
                table: "Chore",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chore_Person_PersonId",
                table: "Chore");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Chore");
        }
    }
}
