using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Countries_CurrentCountryId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CurrentCountryId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CurrentCountryId",
                table: "Characters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentCountryId",
                table: "Characters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CurrentCountryId",
                table: "Characters",
                column: "CurrentCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Countries_CurrentCountryId",
                table: "Characters",
                column: "CurrentCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
