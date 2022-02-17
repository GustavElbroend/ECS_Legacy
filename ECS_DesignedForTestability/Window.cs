using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_DesignedForTestability
{
    
    public class Window : IWindow
    {
        public void OpenWindow()
        {
            Console.WriteLine("Window is open");
        }

        public void CloseWindow()
        {
            Console.WriteLine("Window is closed");
        }
    }
}
