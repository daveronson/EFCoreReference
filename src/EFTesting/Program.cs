using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFTesting.DAL;
using EFTesting.Model;
using Microsoft.Data.Entity;
using EFTesting.App.Menu;
using EFTesting.App.StudentManagement;
using EFTesting.App.CourseManagement;

namespace EFTesting
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var context = new EFTestingContext();
            char MenuSelection;

            do
            {
                MenuSelection = MainMenu.Display();

                switch (MenuSelection)
                {
                    case '1':
                        StudentMenuController.MenuHandler(context);
                        break;
                    case '2':
                        CourseMenuController.MenuHandler(context);
                        break;
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
            } while (MenuSelection != '0');
            return 0;                     
        }
    }

    public static class Extensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
