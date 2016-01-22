using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFTesting.App.Helper;
using EFTesting.Model;
using System.Security.Cryptography;
using System.Text;

namespace EFTesting.View.StudentView
{
    public class StudentView
    {
        public static Student AddStudentView()
        {
            string studentName = "";
            var student = new Student();

            SCHelper.ClearConsole();

            Console.WriteLine("ADD A STUDENT");
            Console.WriteLine("-------------");
            Console.WriteLine("\n");
            Console.Write("Name: ");

            studentName = Console.ReadLine();
            if (studentName != "")
            {
                student.Name = studentName;
                return student;
            }
            else
            {
                Console.WriteLine("Name is a required field.\n");
                Console.Write("\nPress [Enter] key to continue... ");
                Console.ReadLine();
                return null;
            }            
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

        public static int InputStudentIDView()
        {
            string consoleString = "";
            int StudentID;
            bool ValidStudentID;

            SCHelper.ClearConsole();

            Console.Write("Student ID: ");
            consoleString = Console.ReadLine();

            if (consoleString != "")
            {
                ValidStudentID = Int32.TryParse(consoleString, out StudentID);

                if (!ValidStudentID)
                {
                    Console.WriteLine("{0} is an invalid Student ID", consoleString);
                    return 0;
                }
            }
            else
            {
                return 0;
            }

            return StudentID;
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

        public static void ListStudentCoursesView(Student student)
        {
            SCHelper.ClearConsole();

            Console.WriteLine("LIST STUDENT'S COURSES");
            Console.WriteLine("--------------------");
            Console.WriteLine("\n");

            if (student != null)
            {
                Console.WriteLine("{0} ({1}) is enrolled in the following courses:\n",student.Name, student.ID);
                Console.WriteLine("\tCourse ID\tCourse Name");
                foreach (var course in student.StudentCourses)
                {
                    Console.WriteLine("\t{0}\t\t{1}", course.Course.ID, course.Course.Name);
                }
            }
            else
            {
                Console.WriteLine("Student is not in the database");
            }

            Console.Write("\nPress [Enter] key to continue... ");
            Console.ReadLine();
        }

        public static void ListStudentsView(List<Student> students)
        {
            int NumStudents;

            SCHelper.ClearConsole();

            NumStudents = students.Count();

            Console.WriteLine("LIST STUDENTS");
            Console.WriteLine("-------------");
            Console.WriteLine("\n");
            Console.WriteLine("Number of students: {0}", NumStudents);

            Console.WriteLine("\tStudent ID\tName");
            foreach (var student in students)
            {
                Console.WriteLine("\t{0}\t\t{1}", student.ID, student.Name);
            }

            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();

        }
        
        public static void DeleteAllView()
        {
            SCHelper.ClearConsole();
            Console.WriteLine("All students have been deleted.\n");
            Console.WriteLine("Press [Enter] to continue");
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
                Console.Write("\nPress [Enter] key to continue... ");
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
