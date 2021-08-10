using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeCourse.IdentityServer.Migrations
{
    public partial class test_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestField",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestField",
                table: "AspNetUsers");
        }
    }
}
