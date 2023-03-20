using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fronted.Migrations
{
    /// <inheritdoc />
    public partial class PlatformTypeAssessmentReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaliciousEvents_ThreatTypes_ThreatTypeId",
                table: "MaliciousEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThreatTypes",
                table: "ThreatTypes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ThreatTypes");

            migrationBuilder.RenameTable(
                name: "ThreatTypes",
                newName: "PlatformTypes");

            migrationBuilder.RenameColumn(
                name: "ThreatTypeId",
                table: "MaliciousEvents",
                newName: "AssessmentReportId");

            migrationBuilder.RenameIndex(
                name: "IX_MaliciousEvents_ThreatTypeId",
                table: "MaliciousEvents",
                newName: "IX_MaliciousEvents_AssessmentReportId");

            migrationBuilder.AddColumn<int>(
                name: "PlatformTypeId",
                table: "MaliciousEvents",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OperatingSystem",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Ipv4Address",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MacAddress",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformTypes",
                table: "PlatformTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AssessmentReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PulseCount = table.Column<int>(type: "int", nullable: false),
                    MalwareCount = table.Column<int>(type: "int", nullable: false),
                    ThreatType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatformTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentReports_PlatformTypes_PlatformTypeId",
                        column: x => x.PlatformTypeId,
                        principalTable: "PlatformTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaliciousEvents_PlatformTypeId",
                table: "MaliciousEvents",
                column: "PlatformTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentReports_PlatformTypeId",
                table: "AssessmentReports",
                column: "PlatformTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaliciousEvents_AssessmentReports_AssessmentReportId",
                table: "MaliciousEvents",
                column: "AssessmentReportId",
                principalTable: "AssessmentReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaliciousEvents_PlatformTypes_PlatformTypeId",
                table: "MaliciousEvents",
                column: "PlatformTypeId",
                principalTable: "PlatformTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaliciousEvents_AssessmentReports_AssessmentReportId",
                table: "MaliciousEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_MaliciousEvents_PlatformTypes_PlatformTypeId",
                table: "MaliciousEvents");

            migrationBuilder.DropTable(
                name: "AssessmentReports");

            migrationBuilder.DropIndex(
                name: "IX_MaliciousEvents_PlatformTypeId",
                table: "MaliciousEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformTypes",
                table: "PlatformTypes");

            migrationBuilder.DropColumn(
                name: "PlatformTypeId",
                table: "MaliciousEvents");

            migrationBuilder.DropColumn(
                name: "Ipv4Address",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "MacAddress",
                table: "Devices");

            migrationBuilder.RenameTable(
                name: "PlatformTypes",
                newName: "ThreatTypes");

            migrationBuilder.RenameColumn(
                name: "AssessmentReportId",
                table: "MaliciousEvents",
                newName: "ThreatTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MaliciousEvents_AssessmentReportId",
                table: "MaliciousEvents",
                newName: "IX_MaliciousEvents_ThreatTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "OperatingSystem",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ThreatTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThreatTypes",
                table: "ThreatTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaliciousEvents_ThreatTypes_ThreatTypeId",
                table: "MaliciousEvents",
                column: "ThreatTypeId",
                principalTable: "ThreatTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
