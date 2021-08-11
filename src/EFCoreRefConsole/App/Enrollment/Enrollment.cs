using EFCoreRef.DAL;
using EFCoreRef.Model;
using EFCoreRefConsole.App.Enrollment;
using System.Linq;

namespace EFCoreRef.App.EnrollmentManagement
{
    public class Enrollment
    {
        public static void EnrollStudent(EnrollmentViewModel enrollment)
        {
            if (enrollment != null)
            {
                using (var context = new EFCoreRefContext())
                {
                    var student = context.Student.FirstOrDefault(s => s.ID == enrollment.StudentID);
                    var course = context.Course.FirstOrDefault(c => c.ID == enrollment.CourseID);
                    if (student != null && course != null)
                    {
                        //The student and course exist
                        StudentCourse CurrentStudentCourses = context.StudentCourse
                            .Where(sc => sc.StudentID == enrollment.StudentID)
                            .Where(sc => sc.CourseID == enrollment.CourseID)
                            .FirstOrDefault();
                        if (CurrentStudentCourses == null)
                        {
                            //The student isn't currently enrolled so we are good to add them to the course
                            var studentCourse = new StudentCourse();
                            studentCourse.StudentID = enrollment.StudentID;
                            studentCourse.CourseID = enrollment.CourseID;

                            context.StudentCourse.Add(studentCourse);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
