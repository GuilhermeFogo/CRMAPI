using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMAPI.Migrations
{
    public partial class oportunidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClienteId",
                table: "Oportunidade",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oportunidade_ClienteId",
                table: "Oportunidade",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oportunidade_Clientes_ClienteId",
                table: "Oportunidade",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oportunidade_Clientes_ClienteId",
                table: "Oportunidade");

            migrationBuilder.DropIndex(
                name: "IX_Oportunidade_ClienteId",
                table: "Oportunidade");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Oportunidade");
        }
    }
}
