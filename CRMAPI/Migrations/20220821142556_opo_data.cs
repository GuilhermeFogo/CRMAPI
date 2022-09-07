using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMAPI.Migrations
{
    public partial class opo_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "consentimento",
                table: "Clientes",
                newName: "Consentimento");

            migrationBuilder.AddColumn<string>(
                name: "Aprovador",
                table: "Oportunidade",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Oportunidade",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aprovador",
                table: "Oportunidade");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Oportunidade");

            migrationBuilder.RenameColumn(
                name: "Consentimento",
                table: "Clientes",
                newName: "consentimento");
        }
    }
}
