using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelegramBotPractice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUserOfAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "FullName_FirstName");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Authors",
                newName: "FullName_MiddleName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Authors",
                newName: "FullName_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Authors",
                newName: "FullName_FirstName");

            migrationBuilder.AddColumn<long>(
                name: "ChatId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "FullName_LastName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName_MiddleName",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName_LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName_MiddleName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "FullName_FirstName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FullName_MiddleName",
                table: "Authors",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "FullName_LastName",
                table: "Authors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FullName_FirstName",
                table: "Authors",
                newName: "FirstName");
        }
    }
}
