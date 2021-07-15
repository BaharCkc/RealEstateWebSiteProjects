using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateWebSiteProjects.Data.Migrations
{
    public partial class deleteCityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_County_City_CityId",
                table: "County");

            migrationBuilder.DropIndex(
                name: "IX_County_CityId",
                table: "County");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "County");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "County",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_County_CityId",
                table: "County",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_County_City_CityId",
                table: "County",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
