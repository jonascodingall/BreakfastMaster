using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakfastMasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserBreadRollEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBreadRoll");

            migrationBuilder.CreateTable(
                name: "UserBreadRolls",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BreadRollId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBreadRolls", x => new { x.UserId, x.BreadRollId });
                    table.ForeignKey(
                        name: "FK_UserBreadRolls_BreadRolls_BreadRollId",
                        column: x => x.BreadRollId,
                        principalTable: "BreadRolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBreadRolls_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBreadRolls_BreadRollId",
                table: "UserBreadRolls",
                column: "BreadRollId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBreadRolls");

            migrationBuilder.CreateTable(
                name: "UserBreadRoll",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BreadRollId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBreadRoll", x => new { x.UserId, x.BreadRollId });
                    table.ForeignKey(
                        name: "FK_UserBreadRoll_BreadRolls_BreadRollId",
                        column: x => x.BreadRollId,
                        principalTable: "BreadRolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBreadRoll_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBreadRoll_BreadRollId",
                table: "UserBreadRoll",
                column: "BreadRollId");
        }
    }
}
