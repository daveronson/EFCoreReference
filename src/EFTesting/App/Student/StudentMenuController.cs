using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFTesting.App.Menu;
using EFTesting.DAL;
using EFTesting.View.StudentView;
using EFTesting.Model;

namespace EFTesting.App.StudentManagement
{
    public class StudentMenuController
    {
        public static void MenuHandler(EFTestingContext context)
        {
            char MenuSelection;

            do
            {
                MenuSelection = StudentMenu.Display();

                switch (MenuSelection)
                {
                    case '1':
                        var students = new List<Student>();
                        students = StudentManagement.List();
                        StudentView.ListStudentsView(students);
                        break;
                    case '2':
                        var courses = new List<Course>();
                        int studentID = StudentView.GetStudentID();
                        courses = StudentManagement.ListCourses(studentID);
                        StudentView.ListStudentCoursesView(courses);
                        break;
                    case '3':
                        StudentManagement.Create(context);
                        break;
                    case '4':
                        var studentCourse = new StudentCourse();
                        studentCourse = StudentView.EnrollStudentView();
                        StudentManagement.EnrollStudent(studentCourse);
                        break;
                    case '5':
                        StudentManagement.DeleteAll(context);
                        break;
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
            } while (MenuSelection != '0');
        }
    }
}
