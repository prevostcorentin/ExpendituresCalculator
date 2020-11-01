using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpendituresCalculator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spents",
                columns: table => new
                {
                    SpentId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spents", x => x.SpentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spents");
        }
    }
}
