using EFCoreRef.DAL;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;

namespace EFCoreRef.Migrations
{
    [DbContext(typeof(EFCoreRefContext))]
    partial class EFCoreRefContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreRef.Model.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

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
