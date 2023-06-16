using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Project.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Anthem",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeadOfState",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anthem",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "HeadOfState",
                table: "Countries");
        }
    }
}
