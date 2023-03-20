using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fronted.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThreatTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreatTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaliciousEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlVisited = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreatLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreatTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaliciousEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaliciousEvents_ThreatTypes_ThreatTypeId",
                        column: x => x.ThreatTypeId,
                        principalTable: "ThreatTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaliciousEvents_ThreatTypeId",
                table: "MaliciousEvents",
                column: "ThreatTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaliciousEvents");

            migrationBuilder.DropTable(
                name: "ThreatTypes");
        }
    }
}
