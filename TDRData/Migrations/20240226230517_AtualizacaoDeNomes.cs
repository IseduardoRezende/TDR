using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDR.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoDeNomes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Periodo_PeriodoFk",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Votacao_Cardapio_CardapioFk",
                table: "Votacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Votacao_Usuario_UsuarioFk",
                table: "Votacao");

            migrationBuilder.DropColumn(
                name: "Voto",
                table: "Votacao");

            migrationBuilder.DropColumn(
                name: "FuncionalidadeFk",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "UsuarioFk",
                table: "Votacao",
                newName: "UserFk");

            migrationBuilder.RenameColumn(
                name: "DataExclusao",
                table: "Votacao",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Votacao",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CardapioFk",
                table: "Votacao",
                newName: "MenuFk");

            migrationBuilder.RenameIndex(
                name: "IX_Votacao_UsuarioFk",
                table: "Votacao",
                newName: "IX_Votacao_UserFk");

            migrationBuilder.RenameIndex(
                name: "IX_Votacao_CardapioFk",
                table: "Votacao",
                newName: "IX_Votacao_MenuFk");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuario",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "PeriodoFk",
                table: "Usuario",
                newName: "PeriodFk");

            migrationBuilder.RenameColumn(
                name: "DataExclusao",
                table: "Usuario",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Usuario",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_PeriodoFk",
                table: "Usuario",
                newName: "IX_Usuario_PeriodFk");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Periodo",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "DataExclusao",
                table: "Periodo",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Periodo",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "TerminoVotacao",
                table: "Cardapio",
                newName: "StartVote");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Cardapio",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "InicioVotacao",
                table: "Cardapio",
                newName: "EndVote");

            migrationBuilder.RenameColumn(
                name: "DataExclusao",
                table: "Cardapio",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Cardapio",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Cardapio",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Votacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "State",
                table: "Votacao");

            migrationBuilder.RenameColumn(
                name: "UserFk",
                table: "Votacao",
                newName: "UsuarioFk");

            migrationBuilder.RenameColumn(
                name: "MenuFk",
                table: "Votacao",
                newName: "CardapioFk");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Votacao",
                newName: "DataExclusao");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Votacao",
                newName: "DataCriacao");

            migrationBuilder.RenameIndex(
                name: "IX_Votacao_UserFk",
                table: "Votacao",
                newName: "IX_Votacao_UsuarioFk");

            migrationBuilder.RenameIndex(
                name: "IX_Votacao_MenuFk",
                table: "Votacao",
                newName: "IX_Votacao_CardapioFk");

            migrationBuilder.RenameColumn(
                name: "PeriodFk",
                table: "Usuario",
                newName: "PeriodoFk");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuario",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Usuario",
                newName: "DataExclusao");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Usuario",
                newName: "DataCriacao");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_PeriodFk",
                table: "Usuario",
                newName: "IX_Usuario_PeriodoFk");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Periodo",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Periodo",
                newName: "DataExclusao");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Periodo",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "StartVote",
                table: "Cardapio",
                newName: "TerminoVotacao");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cardapio",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "EndVote",
                table: "Cardapio",
                newName: "InicioVotacao");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Cardapio",
                newName: "DataExclusao");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Cardapio",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Cardapio",
                newName: "Data");

            migrationBuilder.AddColumn<int>(
                name: "Voto",
                table: "Votacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "FuncionalidadeFk",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Periodo_PeriodoFk",
                table: "Usuario",
                column: "PeriodoFk",
                principalTable: "Periodo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votacao_Cardapio_CardapioFk",
                table: "Votacao",
                column: "CardapioFk",
                principalTable: "Cardapio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votacao_Usuario_UsuarioFk",
                table: "Votacao",
                column: "UsuarioFk",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
