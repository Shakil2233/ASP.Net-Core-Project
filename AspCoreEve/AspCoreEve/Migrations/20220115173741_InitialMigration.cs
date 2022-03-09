using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspCoreEve.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catagories",
                columns: table => new
                {
                    Cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatagoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catagories", x => x.Cid);
                });

            migrationBuilder.CreateTable(
                name: "BusInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bus_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SitAvailable = table.Column<bool>(type: "bit", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusInformations_Catagories_Cid",
                        column: x => x.Cid,
                        principalTable: "Catagories",
                        principalColumn: "Cid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusInformations_Cid",
                table: "BusInformations",
                column: "Cid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusInformations");

            migrationBuilder.DropTable(
                name: "Catagories");
        }
    }
}
