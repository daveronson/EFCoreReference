using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFTesting.App.Helper;

namespace EFTesting.App.Menu
{
    public class CourseMenu
    {
        public static char Display()
        {
            SCHelper.ClearConsole();

            Console.WriteLine("1  - List all Courses");
            Console.WriteLine("2  - List all Students for a Course");
            Console.WriteLine("3  - Add a Course");
            Console.WriteLine("4  - Enroll Student in Course");
            Console.WriteLine("5  - Delete all Courses");
            Console.WriteLine("0 - Exit");

            return Console.ReadKey().KeyChar;
        }

    }
}
