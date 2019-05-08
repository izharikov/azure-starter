using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Azure.Starter.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Samples",
                columns: new[] { "Id", "Created", "Description", "DisplayName", "Features", "LastUpdated", "Name" },
                values: new object[] { new Guid("307fe9c6-fb15-4e3e-a3d3-494339348380"), new DateTime(2019, 5, 8, 18, 31, 19, 52, DateTimeKind.Local).AddTicks(2555), "[Description]", "[DisplayName]", "Feature #1,Feature #2,Feature #3", new DateTime(2019, 5, 8, 18, 31, 19, 52, DateTimeKind.Local).AddTicks(3023), "[Name]" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samples");
        }
    }
}
