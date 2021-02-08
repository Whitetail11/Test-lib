using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class adminSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "4166278d-eb1a-46ba-98b3-1a5258e94d7b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c779c246-b304-4f50-82b4-047f1fcf6c00", "071a99bc-97de-4d3d-a3e4-6dad4f2a0400", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa61-4af8-bd17-00bd9344e277",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36a6696f-2085-47cb-b095-6b9856745871", null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAELvxX0ytrh+ZhuZuRzvBCFCoYM9O8yu52/q1gTEI5lI2tZPhMUEjfq2O6e4XT0O+1A==", "589b370f-44a5-425e-ab9b-d65a8ebbd06c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c779c246-b304-4f50-82b4-047f1fcf6c00");

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
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07e3e145-450a-45f2-8641-6b56e96f8b60", "admin", null, null, "AQAAAAEAACcQAAAAEJ8G4ObV8UhW0w4wt/bDL6+DH3ozT7E4eoqLBd4a2Ty0gq9sE7IbmTbeDYArhXtIkA==", "017332f8-ac37-4aba-96cb-a93f020573fa" });
        }
    }
}
