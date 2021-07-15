using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateWebSiteProjects.Data.Migrations
{
    public partial class addUserProfileTableField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "UserProfile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description2",
                table: "UserProfile");
        }
    }
}
