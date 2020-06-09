using Microsoft.EntityFrameworkCore.Migrations;

namespace StartSmart.Migrations
{
    public partial class changedAppConexts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4d10892-f43d-4e8e-9bf5-33808bcbad43");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Interests", "LastName", "LockoutEnabled", "LockoutEnd", "MBTI", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "cd450e9f-50f4-4048-9788-f3540f02963f", "User", "kumayla@uci.edu", false, "Kumayl", "Software engineering, Front-end technology", "Abbas", false, null, "INFP", null, null, null, null, false, "b626c8b7-6c83-45c1-9956-0e34d5bd2d68", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Interests", "LastName", "LockoutEnabled", "LockoutEnd", "MBTI", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a4d10892-f43d-4e8e-9bf5-33808bcbad43", 0, "1e5b8f9d-e4ae-49e9-8b19-ae880bb0682a", "User", "kumayla@uci.edu", false, "Kumayl", "Software engineering, Front-end technology", "Abbas", false, null, "INFP", null, null, null, null, false, "b1123249-4ac0-473e-bff9-5f0b46268c1b", false, null });
        }
    }
}
