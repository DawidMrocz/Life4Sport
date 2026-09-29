using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Api.Migrations.SharedDb
{
    /// <inheritdoc />
    public partial class initssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cultures",
                schema: "framework");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                schema: "framework",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                schema: "framework",
                table: "Files",
                newName: "Updated");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "framework",
                table: "Templates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                schema: "framework",
                table: "Templates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "framework",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                schema: "framework",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "framework",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "FileGuid",
                schema: "framework",
                table: "Files",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "framework",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password_PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Password_PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Block_Blocked = table.Column<bool>(type: "bit", nullable: false),
                    Block_UnblockTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Files_Photo = table.Column<int>(type: "int", nullable: true),
                    Files_Documents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                schema: "framework",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "framework",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                schema: "framework",
                table: "Tokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tokens",
                schema: "framework");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "framework");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "framework",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "framework",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "framework",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "framework",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "framework",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileGuid",
                schema: "framework",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "Updated",
                schema: "framework",
                table: "Files",
                newName: "CreateDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                schema: "framework",
                table: "Files",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cultures",
                schema: "framework",
                columns: table => new
                {
                    CultureModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultures", x => x.CultureModelId);
                });
        }
    }
}
