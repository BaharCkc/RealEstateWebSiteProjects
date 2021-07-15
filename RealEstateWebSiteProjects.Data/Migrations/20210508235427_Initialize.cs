using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateWebSiteProjects.Data.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnnouncementCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RecordUserId = table.Column<Guid>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: true),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RecordUserId = table.Column<Guid>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: true),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RecordUserId = table.Column<Guid>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: true),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RecordUserId = table.Column<Guid>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: true),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "County",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RecordUserId = table.Column<Guid>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: true),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_County", x => x.Id);
                    table.ForeignKey(
                        name: "FK_County_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RecordUserId = table.Column<Guid>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: true),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    RegisterName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RecordUserId = table.Column<Guid>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: true),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    AnnouncementCategoryId = table.Column<Guid>(nullable: false),
                    AnnouncementTypeId = table.Column<Guid>(nullable: false),
                    NetSquareMeter = table.Column<string>(nullable: true),
                    GrossSquareMeter = table.Column<string>(nullable: true),
                    NumberOfRooms = table.Column<string>(nullable: true),
                    NumberOfBathrooms = table.Column<string>(nullable: true),
                    FloorLocation = table.Column<string>(nullable: true),
                    IsArticle = table.Column<bool>(nullable: true),
                    HousingAge = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CityId = table.Column<Guid>(nullable: false),
                    CountyId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_AnnouncementCategory_AnnouncementCategoryId",
                        column: x => x.AnnouncementCategoryId,
                        principalTable: "AnnouncementCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Announcements_AnnouncementType_AnnouncementTypeId",
                        column: x => x.AnnouncementTypeId,
                        principalTable: "AnnouncementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Announcements_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Announcements_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AnnouncementCategoryId",
                table: "Announcements",
                column: "AnnouncementCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AnnouncementTypeId",
                table: "Announcements",
                column: "AnnouncementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_CityId",
                table: "Announcements",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_UserId",
                table: "Announcements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_County_CityId",
                table: "County",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "County");

            migrationBuilder.DropTable(
                name: "AnnouncementCategory");

            migrationBuilder.DropTable(
                name: "AnnouncementType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
