using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMAPI.Migrations
{
    public partial class add2camposEnderecos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Enderecos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Enderecos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Enderecos");
        }
    }
}
