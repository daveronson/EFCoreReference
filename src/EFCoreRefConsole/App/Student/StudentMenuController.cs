using EFCoreRef.App.EnrollmentManagement;
using EFCoreRef.App.Menu;
using EFCoreRef.Model;
using EFCoreRef.View.EnrollmentView;
using EFCoreRef.View.StudentView;
using System;
using System.Collections.Generic;

namespace EFCoreRef.App.StudentManagement
{
    public class StudentMenuController
    {
        public static void MenuHandler()
        {
            char MenuSelection;
            var student = new Student();

            do
            {
                MenuSelection = StudentMenu.Display();

                switch (MenuSelection)
                {
                    //List all students
                    case '1':
                        var students = new List<Student>();
                        students = StudentManagement.List();
                        StudentView.ListStudentsView(students);
                        break;
                    //List all courses for a student
                    case '2':
                        int studentID = StudentView.InputStudentIDView();
                        student = StudentManagement.GetStudentByID(studentID);
                        StudentView.ListStudentCoursesView(student);
                        break;
                    //Add a student
                    case '3':
                        student = StudentView.AddStudentView();
                        StudentManagement.AddStudent(student);
                        break;
                    //Enroll a student in a course
                    case '4':
                        var studentCourse = EnrollmentView.EnrollStudentView();
                        Enrollment.EnrollStudent(studentCourse);
                        break;
                    //Delete all students
                    case '5':
                        if (StudentView.InputToDeleteAllView() == "y")
                        {
                            if (StudentView.InputAdminPasswordView() == "y")
                            {
                                StudentManagement.DeleteAll();
                                StudentView.DeleteAllView();
                            }                               
                        }
                        break;
                    //Exit menu
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
