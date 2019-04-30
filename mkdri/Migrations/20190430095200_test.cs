using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MKDRI.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "main",
                table: "Laboratory",
                type: "character varying",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Municipality",
                schema: "main",
                table: "Laboratory",
                type: "character varying",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganisationId",
                schema: "main",
                table: "Laboratory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganisationId",
                schema: "main",
                table: "ContactInformation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Organisation",
                schema: "main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "character varying", maxLength: 200, nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Image = table.Column<string>(type: "character varying", nullable: false),
                    DirectorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organisation_User_DirectorId",
                        column: x => x.DirectorId,
                        principalSchema: "main",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Laboratory_OrganisationId",
                schema: "main",
                table: "Laboratory",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_OrganisationId",
                schema: "main",
                table: "ContactInformation",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisation_DirectorId",
                schema: "main",
                table: "Organisation",
                column: "DirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformation_Organisation_OrganisationId",
                schema: "main",
                table: "ContactInformation",
                column: "OrganisationId",
                principalSchema: "main",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Laboratory_Organisation_OrganisationId",
                schema: "main",
                table: "Laboratory",
                column: "OrganisationId",
                principalSchema: "main",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformation_Organisation_OrganisationId",
                schema: "main",
                table: "ContactInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_Laboratory_Organisation_OrganisationId",
                schema: "main",
                table: "Laboratory");

            migrationBuilder.DropTable(
                name: "Organisation",
                schema: "main");

            migrationBuilder.DropIndex(
                name: "IX_Laboratory_OrganisationId",
                schema: "main",
                table: "Laboratory");

            migrationBuilder.DropIndex(
                name: "IX_ContactInformation_OrganisationId",
                schema: "main",
                table: "ContactInformation");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "main",
                table: "Laboratory");

            migrationBuilder.DropColumn(
                name: "Municipality",
                schema: "main",
                table: "Laboratory");

            migrationBuilder.DropColumn(
                name: "OrganisationId",
                schema: "main",
                table: "Laboratory");

            migrationBuilder.DropColumn(
                name: "OrganisationId",
                schema: "main",
                table: "ContactInformation");
        }
    }
}
