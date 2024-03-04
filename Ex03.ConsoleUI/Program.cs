using System;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            initializeSystemAndStart();
        }

        private static void initializeSystemAndStart()
        {
            SystemController systemController = new SystemController();
            runSystem(systemController);
        }

        private static void runSystem(SystemController i_SystemController)
        {
            try
            {
                i_SystemController.RunSystem();
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Invalid input, press enter to restart the system");
                Console.ReadLine();
                runSystem(i_SystemController);
            }
        }
    }
}
