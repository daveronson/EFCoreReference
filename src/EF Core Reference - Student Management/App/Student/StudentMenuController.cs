﻿using EFCoreRef.App.EnrollmentManagement;
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
                    case '1':
                        var students = new List<Student>();
                        students = StudentManagement.List();
                        StudentView.ListStudentsView(students);
                        break;
                    case '2':
                        int studentID = StudentView.InputStudentIDView();
                        student = StudentManagement.GetStudentByID(studentID);
                        StudentView.ListStudentCoursesView(student);
                        break;
                    case '3':
                        student = null;
                        student = StudentView.AddStudentView();
                        StudentManagement.AddStudent(student);
                        break;
                    case '4':
                        var studentCourse = new StudentCourse();
                        studentCourse = EnrollmentView.EnrollStudentView();
                        Enrollment.EnrollStudent(studentCourse);
                        break;
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
