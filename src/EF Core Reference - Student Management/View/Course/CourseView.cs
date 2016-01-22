using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRef.Model;
using EFCoreRef.App.Helper;
using System.Security.Cryptography;
using System.Text;

namespace EFCoreRef.View.CourseView
{
    public class CourseView
    {
        public static Course AddCourseView()
        {
            string courseName = "";
            var course = new Course();

            SCHelper.ClearConsole();

            Console.WriteLine("ADD A COURSE");
            Console.WriteLine("------------");
            Console.WriteLine("\n");
            Console.Write("Name: ");

            courseName = Console.ReadLine();
            if (courseName != "")
            {
                course.Name = courseName;
                return course;
            }
            else
            {
                Console.WriteLine("Name is a required field.\n");
                Console.Write("\nPress [Enter] key to continue... ");
                Console.ReadLine();
                return null;
            }

        }
        public static void ListCoursesView(List<Course> courses)
        {
            SCHelper.ClearConsole();

            Console.WriteLine("LIST COURSES");
            Console.WriteLine("------------");
            Console.WriteLine("\n");
            Console.WriteLine("Number of courses: {0}", courses.Count());

            Console.WriteLine("\tCourse ID\tName");
            foreach (var course in courses)
            {
                Console.WriteLine("\t{0}\t\t{1}", course.ID, course.Name);
            }

            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();

        }
        public static string InputAdminPasswordView()
        {
            string consoleString = "";
            byte[] consoleStringData = new byte[1024];
            byte[] data = new byte[1024];
            string hash = "";
            SHA512 shaM = new SHA512Managed();

            SCHelper.ClearConsole();

            Console.WriteLine("Enter the admin password: ");
            consoleString = Console.ReadLine();

            consoleStringData = Encoding.UTF8.GetBytes(consoleString);

            data = shaM.ComputeHash(consoleStringData);
            hash = Convert.ToBase64String(data);

            if (hash == "dGxXUL/SxoVRoNjBE6vD+M2Vm9N0yI33UR8YAXKKz2z2NI9RIVZoY8hWhQygKsegtMPPtNxR+P9sAT3JXo2uSQ==")
            {
                return "y";
            }
            else
            {
                Console.WriteLine("\nInvalid password.\n");
                Console.WriteLine("Press [Enter] to continue");
                Console.ReadLine();
                return "n";
            }
        }
        public static int InputCourseIDView()
        {
            string consoleString = "";
            int courseID;
            bool validCourseID;

            SCHelper.ClearConsole();

            Console.Write("Course ID: ");
            consoleString = Console.ReadLine();

            if (consoleString != "")
            {
                validCourseID = Int32.TryParse(consoleString, out courseID);

                if (!validCourseID)
                {
                    Console.WriteLine("{0} is an invalid Course ID", consoleString);
                    return 0;
                }
            }
            else
            {
                return 0;
            }

            return courseID;

        }
        public static void ListStudentsEnrolledInCourse(Course course)
        {
            SCHelper.ClearConsole();

            Console.WriteLine("LIST STUDENTS ENROLLED IN COURSE");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("\n");

            if (course != null)
            {
                Console.WriteLine("The following students are enrolled in {0}:\n", course.Name);
                Console.WriteLine("\tStudent ID\tStudent Name");
                foreach (var student in course.StudentCourses)
                {
                    Console.WriteLine("\t{0}\t\t{1}", student.Student.ID, student.Student.Name);
                }
            }
            else
            {
                Console.WriteLine("Course is not in the database");
            }

            Console.Write("\nPress [Enter] key to continue... ");
            Console.ReadLine();
        }
        public static string InputToDeleteAllView()
        {
            string consoleInput = "";

            SCHelper.ClearConsole();

            Console.WriteLine("Are you sure you want to delete them all? (y/n)");
            consoleInput = Console.ReadLine();

            if (consoleInput.ToLower() == "y")
            {
                return consoleInput;
            }
            else
            {
                return "n";
            }

        }
        public static void DeleteAllView()
        {
            SCHelper.ClearConsole();
            Console.WriteLine("All courses have been deleted.\n");
            Console.WriteLine("Press [Enter] to continue");
            Console.ReadLine();
        }
    }
}
