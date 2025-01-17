using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmadenApi.Migrations
{
    /// <inheritdoc />
    public partial class addingNewColumnInLastPassCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LastPassCards_Folders_folderId",
                table: "LastPassCards");

            migrationBuilder.AlterColumn<int>(
                name: "folderId",
                table: "LastPassCards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Pk_UserId",
                table: "LastPassCards",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "update_at",
                table: "Folders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "create_at",
                table: "Folders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LastPassCards_Folders_folderId",
                table: "LastPassCards",
                column: "folderId",
                principalTable: "Folders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LastPassCards_Folders_folderId",
                table: "LastPassCards");

            migrationBuilder.DropColumn(
                name: "Pk_UserId",
                table: "LastPassCards");

            migrationBuilder.AlterColumn<int>(
                name: "folderId",
                table: "LastPassCards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Folders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Folders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LastPassCards_Folders_folderId",
                table: "LastPassCards",
                column: "folderId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
