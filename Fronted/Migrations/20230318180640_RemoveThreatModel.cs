using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fronted.Migrations
{
    /// <inheritdoc />
    public partial class RemoveThreatModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaliciousEvents_Threat_ThreatId",
                table: "MaliciousEvents");

            migrationBuilder.DropTable(
                name: "Threat");

            migrationBuilder.DropIndex(
                name: "IX_MaliciousEvents_ThreatId",
                table: "MaliciousEvents");

            migrationBuilder.DropColumn(
                name: "ThreatId",
                table: "MaliciousEvents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThreatId",
                table: "MaliciousEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Threat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threat", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaliciousEvents_ThreatId",
                table: "MaliciousEvents",
                column: "ThreatId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaliciousEvents_Threat_ThreatId",
                table: "MaliciousEvents",
                column: "ThreatId",
                principalTable: "Threat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
