using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakfastMasterAPI.Migrations
{
    /// <inheritdoc />
    public partial class AllowDuplicates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBreadRoll",
                table: "UserBreadRoll");

            migrationBuilder.DropIndex(
                name: "IX_UserBreadRoll_UserId",
                table: "UserBreadRoll");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBreadRoll",
                table: "UserBreadRoll",
                columns: new[] { "UserId", "BreadRollId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserBreadRoll_BreadRollId",
                table: "UserBreadRoll",
                column: "BreadRollId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBreadRoll",
                table: "UserBreadRoll");

            migrationBuilder.DropIndex(
                name: "IX_UserBreadRoll_BreadRollId",
                table: "UserBreadRoll");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBreadRoll",
                table: "UserBreadRoll",
                columns: new[] { "BreadRollId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserBreadRoll_UserId",
                table: "UserBreadRoll",
                column: "UserId");
        }
    }
}
