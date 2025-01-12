using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmadenApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewTables20251201 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armazens_Folder_folderId",
                table: "Armazens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Folder",
                table: "Folder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Armazens",
                table: "Armazens");

            migrationBuilder.RenameTable(
                name: "Folder",
                newName: "Folders");

            migrationBuilder.RenameTable(
                name: "Armazens",
                newName: "LastPassCards");

            migrationBuilder.RenameIndex(
                name: "IX_Armazens_folderId",
                table: "LastPassCards",
                newName: "IX_LastPassCards_folderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Folders",
                table: "Folders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LastPassCards",
                table: "LastPassCards",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_at = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_at = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LastPassCards_Folders_folderId",
                table: "LastPassCards",
                column: "folderId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LastPassCards_Folders_folderId",
                table: "LastPassCards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LastPassCards",
                table: "LastPassCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Folders",
                table: "Folders");

            migrationBuilder.RenameTable(
                name: "LastPassCards",
                newName: "Armazens");

            migrationBuilder.RenameTable(
                name: "Folders",
                newName: "Folder");

            migrationBuilder.RenameIndex(
                name: "IX_LastPassCards_folderId",
                table: "Armazens",
                newName: "IX_Armazens_folderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Armazens",
                table: "Armazens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Folder",
                table: "Folder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Armazens_Folder_folderId",
                table: "Armazens",
                column: "folderId",
                principalTable: "Folder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
