using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace eftesting.Migrations
{
    public partial class AddManytoManyFluent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_StudentCourse_Course_CourseID", table: "StudentCourse");
            migrationBuilder.DropForeignKey(name: "FK_StudentCourse_Student_StudentID", table: "StudentCourse");
            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Course_CourseID",
                table: "StudentCourse",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Student_StudentID",
                table: "StudentCourse",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_StudentCourse_Course_CourseID", table: "StudentCourse");
            migrationBuilder.DropForeignKey(name: "FK_StudentCourse_Student_StudentID", table: "StudentCourse");
            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Course_CourseID",
                table: "StudentCourse",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Student_StudentID",
                table: "StudentCourse",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
