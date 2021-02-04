using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class UserBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74474a53-993d-412e-93a2-201a871cfc5e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "d61d6fac-c721-4de6-8fa7-e036ecb867b8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e83124a-5dbc-461b-b878-6bf9b4015bb6", "913fe8be-4967-48f1-ac16-d0bb0253ea97", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa61-4af8-bd17-00bd9344e277",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07e3e145-450a-45f2-8641-6b56e96f8b60", "AQAAAAEAACcQAAAAEJ8G4ObV8UhW0w4wt/bDL6+DH3ozT7E4eoqLBd4a2Ty0gq9sE7IbmTbeDYArhXtIkA==", "017332f8-ac37-4aba-96cb-a93f020573fa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e83124a-5dbc-461b-b878-6bf9b4015bb6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "150a3ed1-b2ae-4149-add7-d2c55bc96674");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "74474a53-993d-412e-93a2-201a871cfc5e", "c6e0626c-95a6-4fb6-982b-19c2de0c942d", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa61-4af8-bd17-00bd9344e277",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a7ae662-7ac6-4111-aa0a-8fe602009947", "AQAAAAEAACcQAAAAEEC0XzDaM0JpXA7eVrXp0+WdjGYR8G82WYziG+zM4RMhOWy8aW49VM1vqDi4xpV5ag==", "f236c260-53d2-488c-a5a4-b5d7eaf97d20" });
        }
    }
}
