using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateWebSiteProjects.Data.Migrations
{
    public partial class deleteUserProfileTableField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description2",
                table: "UserProfile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
