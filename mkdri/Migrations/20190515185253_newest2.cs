using Microsoft.EntityFrameworkCore.Migrations;

namespace MKDRI.Migrations
{
    public partial class newest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Laboratory_LaboratoryId",
                schema: "main",
                table: "Equipment");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Laboratory_LaboratoryId",
                schema: "main",
                table: "Equipment",
                column: "LaboratoryId",
                principalSchema: "main",
                principalTable: "Laboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Laboratory_LaboratoryId",
                schema: "main",
                table: "Equipment");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Laboratory_LaboratoryId",
                schema: "main",
                table: "Equipment",
                column: "LaboratoryId",
                principalSchema: "main",
                principalTable: "Laboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
