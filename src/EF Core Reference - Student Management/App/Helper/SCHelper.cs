using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreRef.App.Helper
{
    public class SCHelper
    {
        public static void ClearConsole()
        {
            #if DNX451
                Console.Clear();
            #endif
        }
    }
}
