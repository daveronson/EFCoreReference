using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace eftesting.Migrations
{
    public partial class RenameCourseNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "Course",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Course",
                newName: "CourseName");
        }
    }
}

