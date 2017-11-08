using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdaptiveLearning.Migrations
{
    public partial class QuizResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavedMathQuizzes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(nullable: false),
                    questions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedMathQuizzes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResultMathQuizzes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmotionalStatePerQuestion = table.Column<string>(nullable: true),
                    SavedMathQuizID = table.Column<int>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    points = table.Column<string>(nullable: true),
                    secsperquestion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultMathQuizzes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ResultMathQuizzes_SavedMathQuizzes_SavedMathQuizID",
                        column: x => x.SavedMathQuizID,
                        principalTable: "SavedMathQuizzes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResultMathQuizzes_SavedMathQuizID",
                table: "ResultMathQuizzes",
                column: "SavedMathQuizID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultMathQuizzes");

            migrationBuilder.DropTable(
                name: "SavedMathQuizzes");
        }
    }
}
