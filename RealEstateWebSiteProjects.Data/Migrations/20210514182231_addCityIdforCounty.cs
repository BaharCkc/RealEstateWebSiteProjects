using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateWebSiteProjects.Data.Migrations
{
    public partial class addCityIdforCounty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "County",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
