using Microsoft.EntityFrameworkCore.Migrations;

namespace StartSmart.Migrations
{
    public partial class changedAppConextss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Interests", "LastName", "LockoutEnabled", "LockoutEnd", "MBTI", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "897dae47-bcaa-431a-abc2-d9706deaae03", "kumayla@uci.edu", false, "Kumayl", "Software engineering, Front-end technology", "Abbas", false, null, "INFP", null, null, null, null, false, "92befaed-bef5-4351-83bf-15521b6965c5", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Interests", "LastName", "LockoutEnabled", "LockoutEnd", "MBTI", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "cd450e9f-50f4-4048-9788-f3540f02963f", "User", "kumayla@uci.edu", false, "Kumayl", "Software engineering, Front-end technology", "Abbas", false, null, "INFP", null, null, null, null, false, "b626c8b7-6c83-45c1-9956-0e34d5bd2d68", false, null });
        }
    }
}
