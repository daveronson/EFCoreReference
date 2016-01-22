using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EFCoreRef.DAL;

namespace EFCoreRef.Migrations
{
    [DbContext(typeof(EFCoreRefContext))]
    [Migration("20151221190718_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreRef.Model.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseName");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("EFCoreRef.Model.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("EFCoreRef.Model.StudentCourse", b =>
                {
                    b.Property<int>("StudentID");

                    b.Property<int>("CourseID");

                    b.HasKey("StudentID", "CourseID");
                });

            modelBuilder.Entity("EFCoreRef.Model.StudentCourse", b =>
                {
                    b.HasOne("EFCoreRef.Model.Course")
                        .WithMany()
                        .HasForeignKey("CourseID");

                    b.HasOne("EFCoreRef.Model.Student")
                        .WithMany()
                        .HasForeignKey("StudentID");
                });
        }
    }
}
