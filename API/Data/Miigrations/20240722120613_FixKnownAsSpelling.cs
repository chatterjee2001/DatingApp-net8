using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Miigrations
{
    /// <inheritdoc />
    public partial class FixKnownAsSpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KnownaAs",
                table: "Users",
                newName: "KnownAs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KnownAs",
                table: "Users",
                newName: "KnownaAs");
        }
    }
}
