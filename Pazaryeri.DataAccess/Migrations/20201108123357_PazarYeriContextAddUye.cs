using Microsoft.EntityFrameworkCore.Migrations;

namespace Pazaryeri.DataAccess.Migrations
{
    public partial class PazarYeriContextAddUye : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uye",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(maxLength: 50, nullable: false),
                    soyad = table.Column<string>(maxLength: 50, nullable: false),
                    telefon = table.Column<string>(maxLength: 20, nullable: false),
                    eposta = table.Column<string>(maxLength: 30, nullable: false),
                    sifre = table.Column<string>(maxLength: 30, nullable: false),
                    AppUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uye", x => x.id);
                    table.ForeignKey(
                        name: "FK_Uye_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uye_AppUserId",
                table: "Uye",
                column: "AppUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uye");
        }
    }
}
