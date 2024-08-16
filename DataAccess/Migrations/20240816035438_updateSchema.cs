using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecruiterRID",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CandidateCID",
                table: "Applications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Applications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recruiters_CityID",
                table: "Recruiters",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_RecruiterRID",
                table: "Jobs",
                column: "RecruiterRID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CandidateCID",
                table: "Applications",
                column: "CandidateCID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CityID",
                table: "Applications",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobID",
                table: "Applications",
                column: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Candidates_CandidateCID",
                table: "Applications",
                column: "CandidateCID",
                principalTable: "Candidates",
                principalColumn: "CID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Cities_CityID",
                table: "Applications",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobID",
                table: "Applications",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Recruiters_RecruiterRID",
                table: "Jobs",
                column: "RecruiterRID",
                principalTable: "Recruiters",
                principalColumn: "RID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recruiters_Cities_CityID",
                table: "Recruiters",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Candidates_CandidateCID",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Cities_CityID",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobID",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Recruiters_RecruiterRID",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Recruiters_Cities_CityID",
                table: "Recruiters");

            migrationBuilder.DropIndex(
                name: "IX_Recruiters_CityID",
                table: "Recruiters");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_RecruiterRID",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Applications_CandidateCID",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_CityID",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_JobID",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "RecruiterRID",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CandidateCID",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Applications");
        }
    }
}
