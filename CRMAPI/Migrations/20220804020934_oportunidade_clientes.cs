using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMAPI.Migrations
{
    public partial class oportunidade_clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Oportunidade",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Oportunidade");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Clientes");
        }
    }
}
