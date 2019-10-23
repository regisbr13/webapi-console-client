using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Webapi.Migrations {
    public partial class v1 : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable (
                name: "Users",
                columns : table => new {
                    Id = table.Column<int> (nullable: false)
                        .Annotation ("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        Login = table.Column<string> (nullable: true),
                        Senha = table.Column<string> (nullable: true)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable (
                name: "Computers",
                columns : table => new {
                    Id = table.Column<int> (nullable: false)
                        .Annotation ("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        Name = table.Column<string> (nullable: true),
                        Ip = table.Column<string> (nullable: true),
                        OS = table.Column<string> (nullable: true),
                        Username = table.Column<string> (nullable: true),
                        DiskSpace = table.Column<string> (nullable: true),
                        MemoryInfo = table.Column<string> (nullable: true),
                        UserId = table.Column<int> (nullable: false)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_Computers", x => x.Id);
                    table.ForeignKey (
                        name: "FK_Computers_Users_UserId",
                        column : x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable (
                name: "Schedulings",
                columns : table => new {
                    Id = table.Column<int> (nullable: false)
                        .Annotation ("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        Comand = table.Column<string> (nullable: true),
                        Response = table.Column<string> (nullable: true),
                        ExecutionDate = table.Column<DateTime> (nullable: false),
                        SchedulingDate = table.Column<DateTime> (nullable: false),
                        ComputerId = table.Column<int> (nullable: false)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_Schedulings", x => x.Id);
                    table.ForeignKey (
                        name: "FK_Schedulings_Computers_ComputerId",
                        column : x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex (
                name: "IX_Computers_UserId",
                table: "Computers",
                column: "UserId");

            migrationBuilder.CreateIndex (
                name: "IX_Schedulings_ComputerId",
                table: "Schedulings",
                column: "ComputerId");
        }

        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable (
                name: "Schedulings");

            migrationBuilder.DropTable (
                name: "Computers");

            migrationBuilder.DropTable (
                name: "Users");
        }
    }
}