using Microsoft.EntityFrameworkCore.Migrations;

namespace Pazaryeri.DataAccess.Migrations
{
    public partial class kategoriMappingModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "resim",
                table: "KategoriTalep",
                maxLength: 250,
                nullable: true,
                defaultValue: "default.png",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "resim",
                table: "KategoriTalep",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true,
                oldDefaultValue: "default.png");
        }
    }
}
