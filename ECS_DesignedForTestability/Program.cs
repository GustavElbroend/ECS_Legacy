using System;
using System.Threading;

namespace ECS_DesignedForTestability
{
    class Program
    {
        static void Main(string[] args)
        {
            IHeater heater = new Heater();
            ITempSensor tempSensor = new TempSensor();
            IWindow window = new Window();

            Console.WriteLine("Testing ECS.Legacy");
            Console.WriteLine("Type 'n' for new values");
            Console.WriteLine("Type 'x' to exit");

            // Make an ECS with a threshold of 23
            var control = new ECS(23, 28, heater, tempSensor, window);

            Thread ECSThread = new Thread(control.Run);
            ECSThread.IsBackground = true;
            ECSThread.Start();

            bool terminate = true;
            while (terminate)
            {
                var key = Console.ReadKey(false);

                if (key.KeyChar == 'n')
                {
                    control.StartIsActive = false;
                    Console.WriteLine("First set the threshold for the heater, then the threshold for det window:");
                    control.SetThreshold(Convert.ToInt32(Console.ReadLine()));
                    control.SetWindowThreshold(Convert.ToInt32(Console.ReadLine()));
                    control.StartIsActive = true;
                }

                if (key.KeyChar == 'x')
                    terminate = false;
            }

            /*
                for (int i = 1; i <= 15; i++)
            {
                Console.WriteLine($"Running regulation number {i}");

                control.Regulate();
            }
            */

        }
    }
}
