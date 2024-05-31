using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class CandicateAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 25464464654L);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "VoteCount",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "IsVoted", "Name", "SurName", "VoteCount" },
                values: new object[,]
                {
                    { 12341234123L, "Candidate", false, "Aday1", "Çetin", 0L },
                    { 23123412341L, "Candidate", false, "Aday3", "Çetin", 0L },
                    { 23412312341L, "Candidate", false, "Aday2", "Çetin", 0L }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "IsVoted", "Name", "SurName" },
                values: new object[,]
                {
                    { 23454545454L, "User", false, "Cenk", "Çetin" },
                    { 25464464654L, "User", false, "Batuhan", "Çetin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12341234123L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23123412341L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23412312341L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23454545454L);

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VoteCount",
                table: "Users");
        }
    }
}
