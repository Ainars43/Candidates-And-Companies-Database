using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeadhuntersCandidatesDatabase.Data.Migrations
{
    /// <inheritdoc />
    public partial class HCDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PositionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyPositions_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyPositions_Position_PositionsId",
                        column: x => x.PositionsId,
                        principalTable: "Position",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidateSkillset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    SkillListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkillset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateSkillset_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSkillset_Skill_SkillListId",
                        column: x => x.SkillListId,
                        principalTable: "Skill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PositionSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    SkillListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionSkills_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionSkills_Skill_SkillListId",
                        column: x => x.SkillListId,
                        principalTable: "Skill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkillset_CandidateId",
                table: "CandidateSkillset",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkillset_SkillListId",
                table: "CandidateSkillset",
                column: "SkillListId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPositions_CompanyId",
                table: "CompanyPositions",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPositions_PositionsId",
                table: "CompanyPositions",
                column: "PositionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionSkills_PositionId",
                table: "PositionSkills",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionSkills_SkillListId",
                table: "PositionSkills",
                column: "SkillListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateSkillset");

            migrationBuilder.DropTable(
                name: "CompanyPositions");

            migrationBuilder.DropTable(
                name: "PositionSkills");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Skill");
        }
    }
}
