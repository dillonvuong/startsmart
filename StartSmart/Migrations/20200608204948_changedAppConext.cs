using Microsoft.EntityFrameworkCore.Migrations;

namespace StartSmart.Migrations
{
    public partial class changedAppConext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Interests", "LastName", "LockoutEnabled", "LockoutEnd", "MBTI", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a4d10892-f43d-4e8e-9bf5-33808bcbad43", 0, "1e5b8f9d-e4ae-49e9-8b19-ae880bb0682a", "User", "kumayla@uci.edu", false, "Kumayl", "Software engineering, Front-end technology", "Abbas", false, null, "INFP", null, null, null, null, false, "b1123249-4ac0-473e-bff9-5f0b46268c1b", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4d10892-f43d-4e8e-9bf5-33808bcbad43");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Interests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MBTI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "Interests", "LastName", "MBTI", "Password", "ProfilePicture" },
                values: new object[] { 1, "kumayla@uci.edu", "Kumayl", "Software engineering, Front-end technology", "Abbas", "INFP", "123456", null });
        }
    }
}
