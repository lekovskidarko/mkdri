using Microsoft.EntityFrameworkCore.Migrations;

namespace MKDRI.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ResearchService_ResearchServiceId",
                schema: "main",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ResearchServiceId",
                schema: "main",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ResearchServiceId",
                schema: "main",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Municipality",
                schema: "main",
                table: "Laboratory");

            migrationBuilder.AlterColumn<int>(
                name: "City",
                schema: "main",
                table: "Laboratory",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ResearchServicePerson",
                schema: "main",
                columns: table => new
                {
                    ResearchServiceId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchServicePerson", x => new { x.ResearchServiceId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ResearchServicePerson_ResearchService_ResearchServiceId",
                        column: x => x.ResearchServiceId,
                        principalSchema: "main",
                        principalTable: "ResearchService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResearchServicePerson_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "main",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResearchServicePerson_UserId",
                schema: "main",
                table: "ResearchServicePerson",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResearchServicePerson",
                schema: "main");

            migrationBuilder.AddColumn<int>(
                name: "ResearchServiceId",
                schema: "main",
                table: "User",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "main",
                table: "Laboratory",
                type: "character varying",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Municipality",
                schema: "main",
                table: "Laboratory",
                type: "character varying",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ResearchServiceId",
                schema: "main",
                table: "User",
                column: "ResearchServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ResearchService_ResearchServiceId",
                schema: "main",
                table: "User",
                column: "ResearchServiceId",
                principalSchema: "main",
                principalTable: "ResearchService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
