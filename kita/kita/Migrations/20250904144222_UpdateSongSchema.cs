using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kita.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSongSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AudioSrc",
                table: "Song",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioSrc",
                table: "Song");
        }
    }
}
