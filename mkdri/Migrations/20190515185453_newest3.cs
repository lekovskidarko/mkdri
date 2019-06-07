using Microsoft.EntityFrameworkCore.Migrations;

namespace MKDRI.Migrations
{
    public partial class newest3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResearchService_Laboratory_LaboratoryId",
                schema: "main",
                table: "ResearchService");

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchService_Laboratory_LaboratoryId",
                schema: "main",
                table: "ResearchService",
                column: "LaboratoryId",
                principalSchema: "main",
                principalTable: "Laboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResearchService_Laboratory_LaboratoryId",
                schema: "main",
                table: "ResearchService");

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchService_Laboratory_LaboratoryId",
                schema: "main",
                table: "ResearchService",
                column: "LaboratoryId",
                principalSchema: "main",
                principalTable: "Laboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
