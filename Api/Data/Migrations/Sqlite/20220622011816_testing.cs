using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharpScape.Api.Data.Migrations.Sqlite
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Commentor",
                columns: new[] { "Id", "Comment", "Name" },
                values: new object[] { 1, "Testing out db 1", "Bob" });

            migrationBuilder.InsertData(
                table: "Commentor",
                columns: new[] { "Id", "Comment", "Name" },
                values: new object[] { 2, "Testing out db 2", "John" });

            migrationBuilder.InsertData(
                table: "Commentor",
                columns: new[] { "Id", "Comment", "Name" },
                values: new object[] { 3, "Testing out db 3", "Sandra" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Commentor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Commentor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Commentor",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
