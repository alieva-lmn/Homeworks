using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Project.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GovernmentForms_Form",
                table: "GovernmentForms");

            migrationBuilder.AlterColumn<string>(
                name: "Form",
                table: "GovernmentForms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Form",
                table: "GovernmentForms",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_GovernmentForms_Form",
                table: "GovernmentForms",
                column: "Form",
                unique: true);
        }
    }
}
