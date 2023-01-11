using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMAPI.Migrations
{
    public partial class opo_vinculado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Vinculado",
                table: "Oportunidade",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vinculado",
                table: "Oportunidade");
        }
    }
}
