using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDR.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoCamposBaseEAdicaoDeCampoEmTabelaVotacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataExclusao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Cardapio");

            migrationBuilder.DropColumn(
                name: "DataExclusao",
                table: "Cardapio");

            migrationBuilder.AddColumn<long>(
                name: "CardapioId",
                table: "Votacao",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDeVotos",
                table: "Votacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "QuantidadeDeVotos",
                table: "Votacao");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Votacao");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataExclusao",
                table: "Usuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Cardapio",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataExclusao",
                table: "Cardapio",
                type: "datetime2",
                nullable: true);

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
    }
}
