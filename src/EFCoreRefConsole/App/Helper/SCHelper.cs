using System;

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
