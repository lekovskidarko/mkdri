using Microsoft.EntityFrameworkCore.Migrations;

namespace MKDRI.Migrations
{
    public partial class permissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaboratoryPermission",
                schema: "main",
                columns: table => new
                {
                    LaboratoryId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryPermission", x => new { x.LaboratoryId, x.UserId });
                    table.ForeignKey(
                        name: "FK_LaboratoryPermission_Laboratory_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalSchema: "main",
                        principalTable: "Laboratory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaboratoryPermission_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "main",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationPermission",
                schema: "main",
                columns: table => new
                {
                    OrganisationId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationPermission", x => new { x.OrganisationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_OrganisationPermission_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalSchema: "main",
                        principalTable: "Organisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganisationPermission_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "main",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryPermission_UserId",
                schema: "main",
                table: "LaboratoryPermission",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationPermission_UserId",
                schema: "main",
                table: "OrganisationPermission",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaboratoryPermission",
                schema: "main");

            migrationBuilder.DropTable(
                name: "OrganisationPermission",
                schema: "main");
        }
    }
}
