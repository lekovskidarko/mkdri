using Microsoft.EntityFrameworkCore.Migrations;

namespace MKDRI.Migrations
{
    public partial class newest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformation_Laboratory_LaboratoryId",
                schema: "main",
                table: "ContactInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformation_Organisation_OrganisationId",
                schema: "main",
                table: "ContactInformation");

            migrationBuilder.AlterColumn<int>(
                name: "City",
                schema: "main",
                table: "Laboratory",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformation_Laboratory_LaboratoryId",
                schema: "main",
                table: "ContactInformation",
                column: "LaboratoryId",
                principalSchema: "main",
                principalTable: "Laboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformation_Organisation_OrganisationId",
                schema: "main",
                table: "ContactInformation",
                column: "OrganisationId",
                principalSchema: "main",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformation_Laboratory_LaboratoryId",
                schema: "main",
                table: "ContactInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformation_Organisation_OrganisationId",
                schema: "main",
                table: "ContactInformation");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "main",
                table: "Laboratory",
                type: "character varying",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformation_Laboratory_LaboratoryId",
                schema: "main",
                table: "ContactInformation",
                column: "LaboratoryId",
                principalSchema: "main",
                principalTable: "Laboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformation_Organisation_OrganisationId",
                schema: "main",
                table: "ContactInformation",
                column: "OrganisationId",
                principalSchema: "main",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
