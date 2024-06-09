using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bnka.Data.Migrations
{
    /// <inheritdoc />
    public partial class ParentPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Parents");
        }
    }
}
