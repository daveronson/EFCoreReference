﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFTesting.App.Helper;

namespace EFTesting.App.Menu
{
    public class MainMenu
    {
        public static char Display()
        {
            SCHelper.ClearConsole();

            Console.WriteLine("1  - Manage Students");
            Console.WriteLine("2  - Manage Courses");
            Console.WriteLine("0 - Exit");

            return Console.ReadKey().KeyChar;
        }
    }
}