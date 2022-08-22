using Microsoft.EntityFrameworkCore.Migrations;

namespace Examination.Core.Migrations
{
    public partial class Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Option_Questions_QuestionId",
                table: "Option");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Option",
                table: "Option");

            migrationBuilder.DropColumn(
                name: "Options",
                table: "TestAnswers");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "TestAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionBank",
                table: "TestAnswers");

            migrationBuilder.DropColumn(
                name: "Student",
                table: "TestAnswers");

            migrationBuilder.RenameTable(
                name: "Option",
                newName: "Options");

            migrationBuilder.RenameIndex(
                name: "IX_Option_QuestionId",
                table: "Options",
                newName: "IX_Options_QuestionId");

            migrationBuilder.AddColumn<int>(
                name: "OptionsId",
                table: "TestAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "TestAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "TestAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswers_OptionsId",
                table: "TestAnswers",
                column: "OptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswers_QuestionId",
                table: "TestAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswers_StudentId",
                table: "TestAnswers",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswers_Options_OptionsId",
                table: "TestAnswers",
                column: "OptionsId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswers_Questions_QuestionId",
                table: "TestAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswers_Students_StudentId",
                table: "TestAnswers",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswers_Options_OptionsId",
                table: "TestAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswers_Questions_QuestionId",
                table: "TestAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswers_Students_StudentId",
                table: "TestAnswers");

            migrationBuilder.DropIndex(
                name: "IX_TestAnswers_OptionsId",
                table: "TestAnswers");

            migrationBuilder.DropIndex(
                name: "IX_TestAnswers_QuestionId",
                table: "TestAnswers");

            migrationBuilder.DropIndex(
                name: "IX_TestAnswers_StudentId",
                table: "TestAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "OptionsId",
                table: "TestAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "TestAnswers");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "TestAnswers");

            migrationBuilder.RenameTable(
                name: "Options",
                newName: "Option");

            migrationBuilder.RenameIndex(
                name: "IX_Options_QuestionId",
                table: "Option",
                newName: "IX_Option_QuestionId");

            migrationBuilder.AddColumn<string>(
                name: "Options",
                table: "TestAnswers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "TestAnswers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionBank",
                table: "TestAnswers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student",
                table: "TestAnswers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Option",
                table: "Option",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Questions_QuestionId",
                table: "Option",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
