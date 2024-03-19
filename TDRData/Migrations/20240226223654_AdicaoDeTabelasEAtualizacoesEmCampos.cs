using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDR.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoDeTabelasEAtualizacoesEmCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeDeVoto",
                table: "Votacao");

            migrationBuilder.DropColumn(
                name: "Periodo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "TipoFuncionalidade",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Intervalo",
                table: "Cardapio");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataExclusao",
                table: "Votacao",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataExclusao",
                table: "Usuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FuncionalidadeFk",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PeriodoFk",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataExclusao",
                table: "Cardapio",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InicioVotacao",
                table: "Cardapio",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TerminoVotacao",
                table: "Cardapio",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Funcionalidade",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionalidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periodo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_FuncionalidadeFk",
                table: "Usuario",
                column: "FuncionalidadeFk");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PeriodoFk",
                table: "Usuario",
                column: "PeriodoFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Funcionalidade_FuncionalidadeFk",
                table: "Usuario",
                column: "FuncionalidadeFk",
                principalTable: "Funcionalidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Periodo_PeriodoFk",
                table: "Usuario",
                column: "PeriodoFk",
                principalTable: "Periodo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Funcionalidade_FuncionalidadeFk",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Periodo_PeriodoFk",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Funcionalidade");

            migrationBuilder.DropTable(
                name: "Periodo");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_FuncionalidadeFk",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PeriodoFk",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataExclusao",
                table: "Votacao");

            migrationBuilder.DropColumn(
                name: "DataExclusao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "FuncionalidadeFk",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PeriodoFk",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataExclusao",
                table: "Cardapio");

            migrationBuilder.DropColumn(
                name: "InicioVotacao",
                table: "Cardapio");

            migrationBuilder.DropColumn(
                name: "TerminoVotacao",
                table: "Cardapio");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDeVoto",
                table: "Votacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Periodo",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoFuncionalidade",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Intervalo",
                table: "Cardapio",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
