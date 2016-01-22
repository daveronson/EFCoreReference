using System.Linq;
using EFCoreRef.Model;
using EFCoreRef.DAL;

namespace EFCoreRef.App.EnrollmentManagement
{
    public class Enrollment
    {
        public static void EnrollStudent(StudentCourse studentCourse)
        {
            if (studentCourse != null)
            {
                using (var context = new EFCoreRefContext())
                {
                    Student student = context.Student.FirstOrDefault(s => s.ID == studentCourse.StudentID);
                    Course course = context.Course.FirstOrDefault(c => c.ID == studentCourse.CourseID);
                    if (student != null && course != null)
                    {
                        //The student and course exist
                        StudentCourse CurrentStudentCourses = context.StudentCourse
                            .Where(sc => sc.StudentID == studentCourse.StudentID)
                            .Where(sc => sc.CourseID == studentCourse.CourseID)
                            .FirstOrDefault();
                        if (CurrentStudentCourses == null)
                        {
                            //The student isn't currently enrolled so we are good to add them to the course
                            context.StudentCourse.Add(studentCourse);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
