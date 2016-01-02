using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFTesting.App.Menu;
using EFTesting.DAL;

namespace EFTesting.App.CourseManagement
{
    public class CourseMenuController
    {
        public static void MenuHandler(EFTestingContext context)
        {
            char MenuSelection;

            do
            {
                MenuSelection = CourseMenu.Display();

                switch (MenuSelection)
                {
                    case '1':
                        CourseManagement.List(context);
                        break;
                    case '2':
                        CourseManagement.ListStudents(context);
                        break;
                    case '3':
                        CourseManagement.Create(context);
                        break;
                    case '4':
                        CourseManagement.EnrollStudent(context);
                        break;
                    case '5':
                        CourseManagement.DeleteAll(context);
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
