using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fronted.Migrations
{
    /// <inheritdoc />
    public partial class PlatformTypeAssessmentReportv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MaliciousEvents_AssessmentReportId",
                table: "MaliciousEvents");

            migrationBuilder.CreateIndex(
                name: "IX_MaliciousEvents_AssessmentReportId",
                table: "MaliciousEvents",
                column: "AssessmentReportId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MaliciousEvents_AssessmentReportId",
                table: "MaliciousEvents");

            migrationBuilder.CreateIndex(
                name: "IX_MaliciousEvents_AssessmentReportId",
                table: "MaliciousEvents",
                column: "AssessmentReportId");
        }
    }
}
