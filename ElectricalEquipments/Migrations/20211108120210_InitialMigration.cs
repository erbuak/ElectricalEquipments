using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectricalEquipments.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Rpm = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motors_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "CodeName", "Name" },
                values: new object[] { 1, "DF1", "Döner Fırın 1" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "CodeName", "Name" },
                values: new object[] { 2, "DF2", "Döner Fırın 2" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "CodeName", "Name" },
                values: new object[] { 3, "ÇD1", "Çimento Değirmeni 1" });

            migrationBuilder.CreateIndex(
                name: "IX_Motors_UnitId",
                table: "Motors",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motors");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
