using System;

namespace ECS_DesignedForTestability
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing ECS.Legacy");
            Console.WriteLine("Type 'n' for new values");
            Console.WriteLine("Type 'x' to exit");

            // Make an ECS with a threshold of 23
            var control = new ECS(23, 28);

            bool terminate = true;
            while (terminate)
            {
                var key = Console.ReadKey(false);

                if (key.KeyChar == 'n')
                {
                    Console.WriteLine("First set the threshold for the heater, then the threshold for det window:");
                    control.SetThreshold(Convert.ToInt32(Console.ReadLine()));
                    control.SetWindowThreshold(Convert.ToInt32(Console.ReadLine()));
                }

                if (key.KeyChar == 'x')
                    terminate = false;


                control.Regulate();
                System.Threading.Thread.Sleep(1000);
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
