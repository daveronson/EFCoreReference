﻿using System;
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
            char MenuSelection;

            do
            {
                MenuSelection = MainMenu.Display();

                switch (MenuSelection)
                {
                    case '1':
                        StudentMenuController.MenuHandler();
                        break;
                    case '2':
                        CourseMenuController.MenuHandler();
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
