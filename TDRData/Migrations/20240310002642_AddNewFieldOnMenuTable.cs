using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDR.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldOnMenuTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Period_PeriodFk",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Menu_MenuFk",
                table: "Vote");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_User_UserFk",
                table: "Vote");

            migrationBuilder.AddColumn<long>(
                name: "PeriodFk",
                table: "Menu",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_PeriodFk",
                table: "Menu",
                column: "PeriodFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Period_PeriodFk",
                table: "Menu",
                column: "PeriodFk",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Period_PeriodFk",
                table: "User",
                column: "PeriodFk",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Menu_MenuFk",
                table: "Vote",
                column: "MenuFk",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_User_UserFk",
                table: "Vote",
                column: "UserFk",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Period_PeriodFk",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Period_PeriodFk",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Menu_MenuFk",
                table: "Vote");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_User_UserFk",
                table: "Vote");

            migrationBuilder.DropIndex(
                name: "IX_Menu_PeriodFk",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "PeriodFk",
                table: "Menu");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Period_PeriodFk",
                table: "User",
                column: "PeriodFk",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Menu_MenuFk",
                table: "Vote",
                column: "MenuFk",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_User_UserFk",
                table: "Vote",
                column: "UserFk",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
