using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMAPI.Migrations
{
    public partial class Oportunidade_ativa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Oportunidade",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Oportunidade");
        }
    }
}
