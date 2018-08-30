using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BluwaterCrmApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndustryTags",
                columns: table => new
                {
                    IndustryTagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IndustryTagGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedTimestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTimestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryTags", x => x.IndustryTagId);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 240, nullable: false),
                    Website = table.Column<string>(nullable: true),
                    WorkPhone = table.Column<string>(nullable: true),
                    ProfileImgUrl = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    FacebookUrl = table.Column<string>(nullable: true),
                    TwitterUrl = table.Column<string>(nullable: true),
                    LinkedInUrl = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    IndustryTagId = table.Column<int>(nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTimestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                    table.ForeignKey(
                        name: "FK_Organizations_IndustryTags_IndustryTagId",
                        column: x => x.IndustryTagId,
                        principalTable: "IndustryTags",
                        principalColumn: "IndustryTagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerGuid = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 120, nullable: false),
                    LastName = table.Column<string>(maxLength: 240, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 240, nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    HomePhone = table.Column<string>(nullable: true),
                    WorkPhone = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    ProfileImgUrl = table.Column<string>(nullable: true),
                    FacebookUrl = table.Column<string>(nullable: true),
                    TwitterUrl = table.Column<string>(nullable: true),
                    LinkedInUrl = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTimestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    DealId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DealGuid = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ApxValue = table.Column<double>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTimestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.DealId);
                    table.ForeignKey(
                        name: "FK_Deals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NoteGuid = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTimestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Notes_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    InteractionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InteractionGuid = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    DealId = table.Column<int>(nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTimestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => x.InteractionId);
                    table.ForeignKey(
                        name: "FK_Interactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interactions_Deals_DealId",
                        column: x => x.DealId,
                        principalTable: "Deals",
                        principalColumn: "DealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerGuid",
                table: "Customers",
                column: "CustomerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OrganizationId",
                table: "Customers",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_CustomerId",
                table: "Deals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_DealGuid",
                table: "Deals",
                column: "DealGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_CustomerId",
                table: "Interactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_DealId",
                table: "Interactions",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_InteractionGuid",
                table: "Interactions",
                column: "InteractionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CustomerId",
                table: "Notes",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_NoteGuid",
                table: "Notes",
                column: "NoteGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_IndustryTagId",
                table: "Organizations",
                column: "IndustryTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationGuid",
                table: "Organizations",
                column: "OrganizationGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interactions");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "IndustryTags");
        }
    }
}
