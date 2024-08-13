using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removedForeginKeyFromJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Recruiters_RID1",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_RID1",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "RID1",
                table: "Jobs",
                newName: "RID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RID",
                table: "Jobs",
                newName: "RID1");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_RID1",
                table: "Jobs",
                column: "RID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Recruiters_RID1",
                table: "Jobs",
                column: "RID1",
                principalTable: "Recruiters",
                principalColumn: "RID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
