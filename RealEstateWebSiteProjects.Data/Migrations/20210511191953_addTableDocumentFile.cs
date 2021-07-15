using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateWebSiteProjects.Data.Migrations
{
    public partial class addTableDocumentFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RecordUserId = table.Column<Guid>(nullable: false),
                    UpdateUserId = table.Column<Guid>(nullable: true),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FilePath = table.Column<string>(nullable: true),
                    AnnouncementId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentFile_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFile_AnnouncementId",
                table: "DocumentFile",
                column: "AnnouncementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentFile");
        }
    }
}
