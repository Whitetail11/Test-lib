using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class BooksSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "fd3fc9c2-6089-4037-8c9a-1778779c9f6d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88346582-5a3d-498a-b788-b77e51c30efe", "eca27b9f-598d-4d11-b3ab-aedecead8119", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa61-4af8-bd17-00bd9344e277",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d15c7a09-19c6-4e53-a033-a4ec3e0d2864", "AQAAAAEAACcQAAAAEJct35DE2LdaZrbs/x/9Z4dixcMyBYQCkiIpoFNbOTV1nNavpw/A7JkSA/XTlW8jcA==", "936ec0ec-4af5-4537-acd7-4606af168f0e" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Amount", "Available", "Name" },
                values: new object[,]
                {
                    { 4, 5, 5, "Математика4" },
                    { 5, 3, 3, "42Математика" },
                    { 6, 1, 1, "99Математика" },
                    { 7, 8, 8, "Математика" },
                    { 8, 2, 2, "1Математика" },
                    { 9, 5, 5, "22Сияние" },
                    { 10, 5, 5, "55Сияние" }
                });

            migrationBuilder.InsertData(
                table: "GetBookAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88346582-5a3d-498a-b788-b77e51c30efe");

            migrationBuilder.DeleteData(
                table: "GetBookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "GetBookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "GetBookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "GetBookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "GetBookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "GetBookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "GetBookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36a6696f-2085-47cb-b095-6b9856745871", "AQAAAAEAACcQAAAAELvxX0ytrh+ZhuZuRzvBCFCoYM9O8yu52/q1gTEI5lI2tZPhMUEjfq2O6e4XT0O+1A==", "589b370f-44a5-425e-ab9b-d65a8ebbd06c" });
        }
    }
}
