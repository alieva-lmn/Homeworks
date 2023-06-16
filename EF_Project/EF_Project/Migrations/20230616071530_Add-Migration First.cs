using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GovernmentForms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Form = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentForms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    GovernmentFormID = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<float>(type: "real", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    GDP = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Countries_GovernmentForms_GovernmentFormID",
                        column: x => x.GovernmentFormID,
                        principalTable: "GovernmentForms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GovernmentFormID",
                table: "Countries",
                column: "GovernmentFormID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GovernmentForms_Form",
                table: "GovernmentForms",
                column: "Form",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "GovernmentForms");
        }
    }
}
