using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDR.Migrations
{
    /// <inheritdoc />
    public partial class RemocaoDeCamposEAlteracaoEmTabelaVotacao : Migration
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

            migrationBuilder.RenameColumn(
                name: "QuantidadeDeVotos",
                table: "Votacao",
                newName: "QuantidadeDeVoto");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioId",
                table: "Votacao",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CardapioId",
                table: "Votacao",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Votacao_Cardapio_CardapioId",
                table: "Votacao",
                column: "CardapioId",
                principalTable: "Cardapio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votacao_Usuario_UsuarioId",
                table: "Votacao",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votacao_Cardapio_CardapioId",
                table: "Votacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Votacao_Usuario_UsuarioId",
                table: "Votacao");

            migrationBuilder.RenameColumn(
                name: "QuantidadeDeVoto",
                table: "Votacao",
                newName: "QuantidadeDeVotos");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioId",
                table: "Votacao",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CardapioId",
                table: "Votacao",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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
