using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addJobTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RID1 = table.Column<int>(type: "int", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecruiterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecruiterContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecruiterEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobPostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModeOfWork = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobID);
                    table.ForeignKey(
                        name: "FK_Jobs_Recruiters_RID1",
                        column: x => x.RID1,
                        principalTable: "Recruiters",
                        principalColumn: "RID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_RID1",
                table: "Jobs",
                column: "RID1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
