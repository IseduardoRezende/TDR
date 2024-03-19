using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDR.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoDeFksEmTabelaVotacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votacao_Cardapio_CardapioId",
                table: "Votacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Votacao_Usuario_UsuarioId",
                table: "Votacao");

            migrationBuilder.DropIndex(
                name: "IX_Votacao_CardapioId",
                table: "Votacao");

            migrationBuilder.DropIndex(
                name: "IX_Votacao_UsuarioId",
                table: "Votacao");

            migrationBuilder.DropColumn(
                name: "CardapioId",
                table: "Votacao");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Votacao");

            migrationBuilder.CreateIndex(
                name: "IX_Votacao_CardapioFk",
                table: "Votacao",
                column: "CardapioFk");

            migrationBuilder.CreateIndex(
                name: "IX_Votacao_UsuarioFk",
                table: "Votacao",
                column: "UsuarioFk");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votacao_Cardapio_CardapioFk",
                table: "Votacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Votacao_Usuario_UsuarioFk",
                table: "Votacao");

            migrationBuilder.DropIndex(
                name: "IX_Votacao_CardapioFk",
                table: "Votacao");

            migrationBuilder.DropIndex(
                name: "IX_Votacao_UsuarioFk",
                table: "Votacao");

            migrationBuilder.AddColumn<long>(
                name: "CardapioId",
                table: "Votacao",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioId",
                table: "Votacao",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votacao_CardapioId",
                table: "Votacao",
                column: "CardapioId");

            migrationBuilder.CreateIndex(
                name: "IX_Votacao_UsuarioId",
                table: "Votacao",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votacao_Cardapio_CardapioId",
                table: "Votacao",
                column: "CardapioId",
                principalTable: "Cardapio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Votacao_Usuario_UsuarioId",
                table: "Votacao",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
