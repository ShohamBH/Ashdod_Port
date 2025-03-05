using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ashdod_Port.Data.Migrations
{
    public partial class MyInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImportersLst",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Num = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportersLst", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuppliersLst",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Num = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuppliersLst", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContainersList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImporterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ImporterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SupplierId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainersList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContainersList_ImportersLst_ImporterId",
                        column: x => x.ImporterId,
                        principalTable: "ImportersLst",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContainersList_SuppliersLst_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "SuppliersLst",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContainersList_ImporterId",
                table: "ContainersList",
                column: "ImporterId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainersList_SupplierId",
                table: "ContainersList",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContainersList");

            migrationBuilder.DropTable(
                name: "ImportersLst");

            migrationBuilder.DropTable(
                name: "SuppliersLst");
        }
    }
}
