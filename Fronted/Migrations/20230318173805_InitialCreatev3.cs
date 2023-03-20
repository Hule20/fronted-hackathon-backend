using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fronted.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "VisitedAt",
                table: "MaliciousEvents",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                        .Annotation("SqlServer:Identity", "1, 1")
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "VisitedAt",
                table: "MaliciousEvents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
