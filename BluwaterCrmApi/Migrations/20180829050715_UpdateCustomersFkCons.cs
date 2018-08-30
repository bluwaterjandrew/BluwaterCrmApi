using Microsoft.EntityFrameworkCore.Migrations;

namespace BluwaterCrmApi.Migrations
{
    public partial class UpdateCustomersFkCons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Organizations_OrganizationId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_OrganizationId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId1",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OrganizationId1",
                table: "Customers",
                column: "OrganizationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Organizations_OrganizationId1",
                table: "Customers",
                column: "OrganizationId1",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Organizations_OrganizationId1",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_OrganizationId1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OrganizationId1",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OrganizationId",
                table: "Customers",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Organizations_OrganizationId",
                table: "Customers",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
