using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFTesting.App.Helper;
using EFTesting.Model;

namespace EFTesting.View.StudentView
{
    public class StudentView
    {
        public static void ListStudentsView(List<Student> students)
        {
            int NumStudents;

            SCHelper.ClearConsole();

            NumStudents = students.Count();
            
            if (NumStudents == 1)
            {
                Console.WriteLine("\nThere is {0} student in the database:", NumStudents);
            }
            else
            {
                Console.WriteLine("\nThere are {0} students in the database:", NumStudents);
            }

            foreach (var student in students)
            {
                Console.WriteLine("\tStudent: ID: {0}  - {1}", student.ID, student.Name);
            }

            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();

        }

        public static int GetStudentID()
        {
            string ConsoleString = "";
            int StudentID;
            bool ValidStudentID;

            SCHelper.ClearConsole();

            Console.Write("Student ID: ");
            ConsoleString = Console.ReadLine();

            if (ConsoleString != "")
            {
                ValidStudentID = Int32.TryParse(ConsoleString, out StudentID);

                if (!ValidStudentID)
                {
                    Console.WriteLine("{0} is an invalid Student ID", ConsoleString);
                    return 0;
                }
            }
            else
            {
                return 0;
            }

            return StudentID;
        }
        public static void ListStudentCoursesView(List<Course> courses)
        {
            if (courses != null)
            {
                Console.WriteLine("\nThe student is enrolled in the following courses:");
                foreach (var course in courses)
                {
                    Console.WriteLine("\t{0} - {1}", course.ID, course.Name);
                }
            }
            else
            {
                Console.WriteLine("Student is not in the database");
            }

            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();
        }
        public static StudentCourse EnrollStudentView()
        {
            string ConsoleString = "";
            int StudentID, CourseID;
            bool ValidStudentID, ValidCourseID = false;
            var studentCourse = new StudentCourse();

            SCHelper.ClearConsole();
            Console.WriteLine("Add Student to Course:");           

            Console.Write("Student ID: ");
            ConsoleString = Console.ReadLine();
            ValidStudentID = Int32.TryParse(ConsoleString, out StudentID);

            Console.Write("Course ID: ");
            ConsoleString = Console.ReadLine();
            ValidCourseID = Int32.TryParse(ConsoleString, out CourseID);

            if (!ValidStudentID || !ValidCourseID)
            {
                Console.WriteLine("Invalid Student ID or Course ID");
                Console.Write("\nPress any key to continue... ");
                Console.ReadLine();
            }
            else
            {
                studentCourse.StudentID = StudentID;
                studentCourse.CourseID = CourseID;
            }
            return studentCourse;

        }
    }
}
