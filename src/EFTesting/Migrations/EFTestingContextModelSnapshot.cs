using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EFTesting.DAL;

namespace eftesting.Migrations
{
    [DbContext(typeof(EFTestingContext))]
    partial class EFTestingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFTesting.Model.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("EFTesting.Model.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("EFTesting.Model.StudentCourse", b =>
                {
                    b.Property<int>("StudentID");

                    b.Property<int>("CourseID");

                    b.HasKey("StudentID", "CourseID");
                });

            modelBuilder.Entity("EFTesting.Model.StudentCourse", b =>
                {
                    b.HasOne("EFTesting.Model.Course")
                        .WithMany()
                        .HasForeignKey("CourseID");

                    b.HasOne("EFTesting.Model.Student")
                        .WithMany()
                        .HasForeignKey("StudentID");
                });
        }
    }
}
