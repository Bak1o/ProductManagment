using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagment.Migrations
{
    /// <inheritdoc />
    public partial class AlterCategory_AddDetailedDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailedDescription",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailedDescription",
                table: "Categories");
        }
    }
}
