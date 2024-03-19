using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDR.Migrations
{
    /// <inheritdoc />
    public partial class RemocaoDeTabelaFuncionalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Funcionalidade_FuncionalidadeFk",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Funcionalidade");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_FuncionalidadeFk",
                table: "Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_FuncionalidadeFk",
                table: "Usuario",
                column: "FuncionalidadeFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Funcionalidade_FuncionalidadeFk",
                table: "Usuario",
                column: "FuncionalidadeFk",
                principalTable: "Funcionalidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
