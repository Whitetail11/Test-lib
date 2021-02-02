using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class SeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "150a3ed1-b2ae-4149-add7-d2c55bc96674", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "74474a53-993d-412e-93a2-201a871cfc5e", "c6e0626c-95a6-4fb6-982b-19c2de0c942d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa61-4af8-bd17-00bd9344e277", 0, "4a7ae662-7ac6-4111-aa0a-8fe602009947", "admin@gmail.com", false, false, null, "admin", null, null, "AQAAAAEAACcQAAAAEEC0XzDaM0JpXA7eVrXp0+WdjGYR8G82WYziG+zM4RMhOWy8aW49VM1vqDi4xpV5ag==", null, false, "f236c260-53d2-488c-a5a4-b5d7eaf97d20", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "a18be9c0-aa61-4af8-bd17-00bd9344e277" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74474a53-993d-412e-93a2-201a871cfc5e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "a18be9c0-aa61-4af8-bd17-00bd9344e277" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa61-4af8-bd17-00bd9344e277");
        }
    }
}
