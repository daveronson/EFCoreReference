using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRef.Model;
using EFCoreRef.App.Helper;

namespace EFCoreRef.View.EnrollmentView
{
    public class EnrollmentView
    {
        public static StudentCourse EnrollStudentView()
        {
            string consoleInput = "";
            int studentID, courseID;
            bool validStudentID, validCourseID = false;
            var studentCourse = new StudentCourse();

            SCHelper.ClearConsole();
            Console.WriteLine("Add Student to Course:");

            Console.Write("Student ID: ");
            consoleInput = Console.ReadLine();
            validStudentID = Int32.TryParse(consoleInput, out studentID);

            Console.Write("Course ID: ");
            consoleInput = Console.ReadLine();
            validCourseID = Int32.TryParse(consoleInput, out courseID);

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
