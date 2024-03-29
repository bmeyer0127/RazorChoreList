using Microsoft.EntityFrameworkCore.Migrations;

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
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChoreName = table.Column<string>(type: "TEXT", nullable: false),
                    CompletionStatus = table.Column<string>(type: "TEXT", nullable: false),
                    PeopleID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chore", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PeopleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    ChoreID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PeopleID);
                    table.ForeignKey(
                        name: "FK_People_Chore_ChoreID",
                        column: x => x.ChoreID,
                        principalTable: "Chore",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chore_PeopleID",
                table: "Chore",
                column: "PeopleID");

            migrationBuilder.CreateIndex(
                name: "IX_People_ChoreID",
                table: "People",
                column: "ChoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chore_People_PeopleID",
                table: "Chore",
                column: "PeopleID",
                principalTable: "People",
                principalColumn: "PeopleID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chore_People_PeopleID",
                table: "Chore");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Chore");
        }
    }
}
