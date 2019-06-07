using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MKDRI.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "main");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstName = table.Column<string>(type: "character varying", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "character varying", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.UniqueConstraint("AK_User_Email", x => x.Email);
                });

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
                    City = table.Column<int>(nullable: false),
                    CoordinatorId = table.Column<int>(nullable: true),
                    OrganisationId = table.Column<int>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Laboratory_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalSchema: "main",
                        principalTable: "Organisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactInformation",
                schema: "main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "character varying", maxLength: 250, nullable: false),
                    LaboratoryId = table.Column<int>(nullable: true),
                    OrganisationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInformation_Laboratory_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalSchema: "main",
                        principalTable: "Laboratory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactInformation_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalSchema: "main",
                        principalTable: "Organisation",
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
                name: "LaboratoryTeam",
                schema: "main",
                columns: table => new
                {
                    LaboratoryId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryTeam", x => new { x.LaboratoryId, x.UserId });
                    table.ForeignKey(
                        name: "FK_LaboratoryTeam_Laboratory_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalSchema: "main",
                        principalTable: "Laboratory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaboratoryTeam_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "main",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_ContactInformation_LaboratoryId",
                schema: "main",
                table: "ContactInformation",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_OrganisationId",
                schema: "main",
                table: "ContactInformation",
                column: "OrganisationId");

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
                name: "IX_Laboratory_OrganisationId",
                schema: "main",
                table: "Laboratory",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryTeam_UserId",
                schema: "main",
                table: "LaboratoryTeam",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisation_DirectorId",
                schema: "main",
                table: "Organisation",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchService_LaboratoryId",
                schema: "main",
                table: "ResearchService",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchServicePerson_UserId",
                schema: "main",
                table: "ResearchServicePerson",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInformation",
                schema: "main");

            migrationBuilder.DropTable(
                name: "Equipment",
                schema: "main");

            migrationBuilder.DropTable(
                name: "LaboratoryTeam",
                schema: "main");

            migrationBuilder.DropTable(
                name: "ResearchServicePerson",
                schema: "main");

            migrationBuilder.DropTable(
                name: "ResearchService",
                schema: "main");

            migrationBuilder.DropTable(
                name: "Laboratory",
                schema: "main");

            migrationBuilder.DropTable(
                name: "Organisation",
                schema: "main");

            migrationBuilder.DropTable(
                name: "User",
                schema: "main");
        }
    }
}
