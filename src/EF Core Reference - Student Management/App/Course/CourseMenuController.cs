using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFTesting.App.EnrollmentManagement;
using EFTesting.App.Menu;
using EFTesting.Model;
using EFTesting.View.CourseView;
using EFTesting.View.EnrollmentView;


namespace EFTesting.App.CourseManagement
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
                    case '1':
                        var courses = new List<Course>();
                        courses = CourseManagement.List();
                        CourseView.ListCoursesView(courses);
                        break;
                    case '2':
                        course = null;
                        int courseID = CourseView.InputCourseIDView();
                        course = CourseManagement.GetCourseByID(courseID);
                        CourseView.ListStudentsEnrolledInCourse(course);
                        break;
                    case '3':
                        course = null;
                        course = CourseView.AddCourseView();
                        CourseManagement.AddCourse(course);
                        break;
                    case '4':
                        var studentCourse = new StudentCourse();
                        studentCourse = EnrollmentView.EnrollStudentView();
                        Enrollment.EnrollStudent(studentCourse);
                        break;
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
