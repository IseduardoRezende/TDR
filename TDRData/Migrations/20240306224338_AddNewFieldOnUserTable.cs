using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDR.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldOnUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Periodo_PeriodFk",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Votacao_Cardapio_MenuFk",
                table: "Votacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Votacao_Usuario_UserFk",
                table: "Votacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votacao",
                table: "Votacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Periodo",
                table: "Periodo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cardapio",
                table: "Cardapio");

            migrationBuilder.RenameTable(
                name: "Votacao",
                newName: "Vote");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Periodo",
                newName: "Period");

            migrationBuilder.RenameTable(
                name: "Cardapio",
                newName: "Menu");

            migrationBuilder.RenameIndex(
                name: "IX_Votacao_UserFk",
                table: "Vote",
                newName: "IX_Vote_UserFk");

            migrationBuilder.RenameIndex(
                name: "IX_Votacao_MenuFk",
                table: "Vote",
                newName: "IX_Vote_MenuFk");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_PeriodFk",
                table: "User",
                newName: "IX_User_PeriodFk");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vote",
                table: "Vote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Period",
                table: "Period",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vote",
                table: "Vote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Period",
                table: "Period");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "User");

            migrationBuilder.RenameTable(
                name: "Vote",
                newName: "Votacao");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "Period",
                newName: "Periodo");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Cardapio");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_UserFk",
                table: "Votacao",
                newName: "IX_Votacao_UserFk");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_MenuFk",
                table: "Votacao",
                newName: "IX_Votacao_MenuFk");

            migrationBuilder.RenameIndex(
                name: "IX_User_PeriodFk",
                table: "Usuario",
                newName: "IX_Usuario_PeriodFk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votacao",
                table: "Votacao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Periodo",
                table: "Periodo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cardapio",
                table: "Cardapio",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Periodo_PeriodFk",
                table: "Usuario",
                column: "PeriodFk",
                principalTable: "Periodo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votacao_Cardapio_MenuFk",
                table: "Votacao",
                column: "MenuFk",
                principalTable: "Cardapio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votacao_Usuario_UserFk",
                table: "Votacao",
                column: "UserFk",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
