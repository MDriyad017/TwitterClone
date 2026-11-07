using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterClone.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TweetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Tweet",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Tweet_UserId",
                table: "Tweet",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tweet_Users_UserId",
                table: "Tweet",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweet_Users_UserId",
                table: "Tweet");

            migrationBuilder.DropIndex(
                name: "IX_Tweet_UserId",
                table: "Tweet");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Tweet",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);
        }
    }
}
