using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Minha_Primeira_Api_Tura_I.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Apelido = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Cadastro = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItem", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TodoItem",
                columns: new[] { "Id", "Apelido", "Ativo", "Cadastro", "Nome" },
                values: new object[,]
                {
                    { 1, "UM", true, new DateTime(2024, 4, 4, 20, 39, 43, 48, DateTimeKind.Local).AddTicks(8252), "Teste UM" },
                    { 2, null, false, new DateTime(2024, 4, 4, 20, 39, 43, 48, DateTimeKind.Local).AddTicks(8262), "Teste DOIS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItem");
        }
    }
}
