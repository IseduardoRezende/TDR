using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDR.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoColunaEmTabelaCardapio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Intervalo",
                table: "Cardapio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Intervalo",
                table: "Cardapio",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
