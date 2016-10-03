using EFCoreRef.App.EnrollmentManagement;
using EFCoreRef.App.Menu;
using EFCoreRef.Model;
using EFCoreRef.View.CourseView;
using EFCoreRef.View.EnrollmentView;
using System;
using System.Collections.Generic;


namespace EFCoreRef.App.CourseManagement
{
    public class CourseMenuController
    {
        public static void MenuHandler()
        {
            char MenuSelection;
            var course = new Course();

            do
            {
                MenuSelection = CourseMenu.Display();

                switch (MenuSelection)
                {
                    //List all courses
                    case '1':
                        var courses = new List<Course>();
                        courses = CourseManagement.List();
                        CourseView.ListCoursesView(courses);
                        break;
                    //List all students for a course
                    case '2':
                        course = null;
                        int courseID = CourseView.InputCourseIDView();
                        course = CourseManagement.GetCourseByID(courseID);
                        CourseView.ListStudentsEnrolledInCourse(course);
                        break;
                    //Add a course
                    case '3':
                        course = null;
                        course = CourseView.AddCourseView();
                        CourseManagement.AddCourse(course);
                        break;
                    //Enroll student in a course
                    case '4':
                        var studentCourse = new StudentCourse();
                        studentCourse = EnrollmentView.EnrollStudentView();
                        Enrollment.EnrollStudent(studentCourse);
                        break;
                    //Delete all courses
                    case '5':
                        if (CourseView.InputToDeleteAllView() == "y")
                        {
                            if (CourseView.InputAdminPasswordView() == "y")
                            {
                                CourseManagement.DeleteAll();
                                CourseView.DeleteAllView();
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
