using Microsoft.EntityFrameworkCore.Migrations;

namespace Webapi.Migrations {
    public partial class v2 : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.RenameColumn (
                name: "Senha",
                table: "Users",
                newName: "Password");
        }

        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.RenameColumn (
                name: "Password",
                table: "Users",
                newName: "Senha");
        }
    }
}