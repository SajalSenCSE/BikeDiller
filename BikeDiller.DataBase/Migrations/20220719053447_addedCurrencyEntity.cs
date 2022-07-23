using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeDiller.DataBase.Migrations
{
    public partial class addedCurrencyEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Bikes");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Bikes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_CurrencyId",
                table: "Bikes",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_Currencies_CurrencyId",
                table: "Bikes",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_Currencies_CurrencyId",
                table: "Bikes");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Bikes_CurrencyId",
                table: "Bikes");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Bikes");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Bikes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
