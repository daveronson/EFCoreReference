using EFCoreRef.App.Helper;
using System;

namespace EFCoreRef.App.Menu
{
    public class StudentMenu
    {
        public static char Display()
        {
            SCHelper.ClearConsole();

            Console.WriteLine("1 - List all Students");
            Console.WriteLine("2 - List all Courses for a Student");
            Console.WriteLine("3 - Add a Student");
            Console.WriteLine("4 - Enroll Student in Course");
            Console.WriteLine("5 - Delete all Students");           
            Console.WriteLine("0 - Exit");

            return Console.ReadKey().KeyChar;
        }
    }
}
