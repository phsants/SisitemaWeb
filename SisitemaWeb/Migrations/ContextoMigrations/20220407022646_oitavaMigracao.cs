using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisitemaWeb.Migrations.ContextoMigrations
{
    public partial class oitavaMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdUser",
                table: "Conta",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Conta");
        }
    }
}
