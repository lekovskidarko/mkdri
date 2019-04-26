using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MKDRI.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                schema: "main",
                table: "User",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaboratoryId",
                schema: "main",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResearchServiceId",
                schema: "main",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactInformation",
                schema: "main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "character varying", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laboratory",
                schema: "main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "character varying", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Visits = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    CoordinatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laboratory_User_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalSchema: "main",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                schema: "main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "character varying", maxLength: 200, nullable: false),
                    CatalogName = table.Column<string>(type: "character varying", maxLength: 200, nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Manufacturer = table.Column<string>(type: "character varying", maxLength: 200, nullable: true),
                    DataSheet = table.Column<string>(type: "character varying", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageLink = table.Column<string>(nullable: true),
                    LaboratoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Laboratory_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalSchema: "main",
                        principalTable: "Laboratory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResearchService",
                schema: "main",
                columns: table => new
                {
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "character varying", maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LaboratoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchService_Laboratory_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalSchema: "main",
                        principalTable: "Laboratory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_LaboratoryId",
                schema: "main",
                table: "User",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ResearchServiceId",
                schema: "main",
                table: "User",
                column: "ResearchServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_LaboratoryId",
                schema: "main",
                table: "Equipment",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratory_CoordinatorId",
                schema: "main",
                table: "Laboratory",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchService_LaboratoryId",
                schema: "main",
                table: "ResearchService",
                column: "LaboratoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Laboratory_LaboratoryId",
                schema: "main",
                table: "User",
                column: "LaboratoryId",
                principalSchema: "main",
                principalTable: "Laboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Laboratory_LaboratoryId",
                schema: "main",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ResearchService_ResearchServiceId",
                schema: "main",
                table: "User");

            migrationBuilder.DropTable(
                name: "ContactInformation",
                schema: "main");

            migrationBuilder.DropTable(
                name: "Equipment",
                schema: "main");

            migrationBuilder.DropTable(
                name: "ResearchService",
                schema: "main");

            migrationBuilder.DropTable(
                name: "Laboratory",
                schema: "main");

            migrationBuilder.DropIndex(
                name: "IX_User_LaboratoryId",
                schema: "main",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ResearchServiceId",
                schema: "main",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LaboratoryId",
                schema: "main",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ResearchServiceId",
                schema: "main",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                schema: "main",
                table: "User",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }
    }
}
