using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS_DesignedForTestability;


namespace ECSRefactorUnitTests
{
    public class FakeTempSensor : ITempSensor
    {
        public int Temp { get; set; }
        public int GetTemp()
        {
            return Temp;
        }

        public bool RunSelfTest()
        {
            throw new NotImplementedException();
        }
    }
}
