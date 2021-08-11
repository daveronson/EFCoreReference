using EFCoreRef.Model;
using EFCoreRefConsole.App.Enrollment;
using System;

namespace EFCoreRef.View.EnrollmentView
{
    public class EnrollmentView
    {
        public static EnrollmentViewModel EnrollStudentView()
        {
            Console.Clear();
            Console.WriteLine("Add Student to Course:");

            Console.Write("Student ID: ");
            var consoleInput = Console.ReadLine();
            var validStudentID = Int32.TryParse(consoleInput, out int studentID);

            Console.Write("Course ID: ");
            consoleInput = Console.ReadLine();
            var validCourseID = int.TryParse(consoleInput, out int courseID);

            var studentCourse = new EnrollmentViewModel();
            if (!validStudentID || !validCourseID)
            {
                Console.WriteLine("Invalid Student ID or Course ID");
                Console.Write("\nPress [Enter] key to continue... ");
                Console.ReadLine();
            }
            else
            {
                studentCourse.StudentID = studentID;
                studentCourse.CourseID = courseID;
            }

            return studentCourse;
        }
    }
}
